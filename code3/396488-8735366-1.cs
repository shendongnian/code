    class InvokeFromMe
    {
        public event EventHandler RaiseMe;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var fromMe = new InvokeFromMe();
            fromMe.RaiseMe += fromMe_RaiseMe;
            fromMe.RaiseMe += fromMe_RaiseMe1;
            fromMe.RaiseMe += fromMe_RaiseMe2;
            FireEvent(fromMe, "RaiseMe", null, EventArgs.Empty);
        }
        static void fromMe_RaiseMe(object sender, EventArgs e)
        {
            Console.WriteLine("Event Handler 0 Raised");
        }
        static void fromMe_RaiseMe1(object sender, EventArgs e)
        {
            Console.WriteLine("Event Handler 1 Raised");
        }
        static void fromMe_RaiseMe2(object sender, EventArgs e)
        {
            Console.WriteLine("Event Handler 2 Raised");
        }
        public static void FireEvent(object onMe, string invokeMe, params object[] eventParams)
        {
            MulticastDelegate eventDelagate =
                  (MulticastDelegate)onMe.GetType().GetField(invokeMe,
                   System.Reflection.BindingFlags.Instance |
                   System.Reflection.BindingFlags.NonPublic).GetValue(onMe);
            Delegate[] delegates = eventDelagate.GetInvocationList();
            foreach (Delegate dlg in delegates)
            {
                dlg.Method.Invoke(dlg.Target, eventParams);
            }
        } 
    }
    class InvokeFromMe
    {
        public event EventHandler RaiseMe;
    }
