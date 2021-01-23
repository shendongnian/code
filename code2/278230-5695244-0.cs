    public class EventSource
    {
        public event EventHandler Test;
    
        public void TriggerEvent()
        {
           Test(this, EventArgs.Empty);
     
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            EventSource src = new EventSource ();
            PlayWithEvent (src);
        }
    
        static void PlayWithEvent (EventSource e)
        {
           src.TriggerEvent();
        }
    }
