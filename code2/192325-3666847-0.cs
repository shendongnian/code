    static class Program
    {
        public static Form1 f1=null;
        public static Form2 f2 = null;
        
        public static FullClose=false;
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            f1=new Form1();
            f2 = new Form2();
            
            Application.Run(f1);
        }
    }
