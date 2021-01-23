    using System;
    using System.Windows.Forms;
    static class Program
       [STAThread]
       static void Main() {
          Application.Run(new myClass());
       }
       internal class myClass : ApplicationContext {
          public myClass() {
             var window = new myWindow();
             window.Show();
             ExitThread();
          }
       }
    }
