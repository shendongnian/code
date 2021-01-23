        private void testit()
        {
            WithEvents we = new WithEvents();
            we.myEvent += new EventHandler(we_myEvent);
            we.myEvent += new EventHandler(we_myEvent2);
            foreach (EventInfo ev in we.GetType().GetEvents())
            {
                FieldInfo fi = we.GetType().GetField(ev.Name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                Delegate del = (Delegate)fi.GetValue(we);
                var list = del.GetInvocationList();
                foreach (var d in list)
                {
                    Console.WriteLine("{0}", d.Method.Name);
                }
            }
        }
        void we_myEvent(object sender, EventArgs e)
        {
        }
        void we_myEvent2(object sender, EventArgs e)
        {
        }
    
    public class WithEvents
    {
        public event EventHandler myEvent;
    }
