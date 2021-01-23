    public class MyClass
    {
        public MyClass(out System.EventHandler idleTrigger)
        {
            idleTrigger = WhenAppIsIdle;
        }
        public void WhenAppIsIdle(object sender, EventArgs e)
        {
            // Do something
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.EventHandler idleEvent;
            MyClass obj = new MyClass(out idleEvent);
            System.Windows.Forms.Application.Idle += idleEvent;
        }
    }
