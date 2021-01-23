        static class Program {
            [STAThread]
            static void Main() {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                MyApp.Run( new MyMainForm() );
            }
        }
    
