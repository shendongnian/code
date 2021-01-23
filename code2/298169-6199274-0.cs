    static class Program
    {
        MyComObject m_Object;
        [STAThread]
        static void Main()
        {
            m_Object = new MyComObject();
            m_Object.OnEvent += ObjectEvt;
            System.Windows.Forms.Application.Run();
        }
        void ObjectEvt(/*...*/)
        {
            // ...
        }
    }
