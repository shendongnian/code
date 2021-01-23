    static class Program
    {
        private static NotifyDelegate m_Notifier;
        static void Main(string[] args)
        {
            m_Notifier = new NotifyDelegate(Notify);
            NewClass oNewClass = new NewClass(m_Notifier);
            // Your work code here
        }
        static void Notify(string Msg)
        {
            Console.WriteLine(Msg);
        }
    }
