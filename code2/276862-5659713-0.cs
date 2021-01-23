    namespace UIThreadMarshalling {
        static class Program {
            [STAThread]
            static void Main() {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var tt = new ThreadTest();
                    ThreadStart ts = new ThreadStart(tt.StartUiThread);
                    Thread t = new Thread(ts);
                    t.Name = "UI Thread";
                    t.Start();
                    Thread.Sleep(new TimeSpan(0, 0, 10));
            }
    
        }
    
     public class ThreadTest {
            Form _form;
            public ThreadTest() {
            }
      
         public void StartUiThread()
         {
            using (Form1 _form = new Form1())
            {
                Application.Run(_form);
            }
         }
      }
    }
 
