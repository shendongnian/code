        using System;
        using System.Windows.Forms;
        using Microsoft.VisualBasic.ApplicationServices;
        namespace WindowsFormsApplication1
        {
           static class Program
           {
              [STAThread]
              static void Main(string[] args)
              {
                 Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 new SplashScreenApp().Run(args);
              }
           }
    
           public class SplashScreenApp : WindowsFormsApplicationBase
           {
              protected override void OnCreateSplashScreen()
              {
                 this.SplashScreen = new SplashForm();
                 this.SplashScreen.ShowInTaskbar = false;
                 this.SplashScreen.Cursor = Cursors.AppStarting;
              }
      
                 protected override void OnCreateMainForm()
                 {
                     //Perform any tasks you want before your application starts
     
                     //FOR TESTING PURPOSES ONLY (remove once you've added your code)
                     System.Threading.Thread.Sleep(2000);
    
                    //Set the main form to a new instance of your form
                    //(this will automatically close the splash screen)
                    this.MainForm = new Form1();
                  }
               }
            }
