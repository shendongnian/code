namespace MyCustomAPI
{
    public interface I_Networking
    {
        /// <summary>
        /// Triggered when a message is received through the TCP socket
        /// </summary>
        /// <param name="message">The message received through the TCP socket</param>
        void HandleMessage(string message);
        /// TODO: Implement send message function
        object SendMessage(object param1, object param2);
    }
}
This is the [separation of concerns][1] approach. The dll should only be concerned with what it should be doing, not the other part trying to use it.  
  [1]: https://en.wikipedia.org/wiki/Separation_of_concerns
