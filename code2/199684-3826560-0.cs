    public class Foo
    {
        public int GetSubscriberCount()
        {
            var count = 0;
            var eventHandler = this.CustomEvent;
            if(eventHandler != null)
            {
                count = eventHandler.GetInvocationList().Length;
            }
            return count;
        }
        public event EventHandler CustomEvent;
    }
