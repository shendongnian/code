    class Program
    {
        static void Main(string[] args)
        {
            Sender _sender = new Sender();
            Receiver _receiver = new Receiver();
            using (ManualResetEvent waitHandle = new ManualResetEvent(false))
            {
                // have to initialize this variable, otherwise the compiler complains when it is used later
                int randomNumber = 0;
                Thread thread1 = new Thread(new ThreadStart(() =>
                {
                    randomNumber = _sender.GenerateNumber();
                    // now that we have the random number, single the wait handle
                    waitHandle.Set();
                }));
                // begin receiving the random number
                thread1.Start();
                // wait for the random number
                if (waitHandle.WaitOne(/*optionally pass in a timeout value*/))
                {
                    _receiver.TakeRandomNumber(randomNumber);
                }
                else
                {
                    // signal was never received
                    // Note, this code will only execute if a timeout value is specified
                }
            }
        }
    }
    public class Sender
    {
        public int GenerateNumber()
        {
            // http://xkcd.com/221/
            int randomNumber = 4; // chosen by fair dice role
            return randomNumber;
        }
    }
    public class Receiver
    {
        public void TakeRandomNumber(int randomNumber)
        {
            // do something
        }
    }
