    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    
    			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
    
    			new Thread(() => new Thread(() => { throw new ApplicationException("Ciao"); }).Start()).Start();
    
    			try
    			{
    				Application.Run(new Form1());
    			}
    			catch (Exception exc)
    			{
    				System.Diagnostics.Debug.WriteLine(exc.Message);
    			}
    		}
    
    		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    		{
    			// here catching Unhandled Exceptions
    			System.Diagnostics.Debug.WriteLine(e.ExceptionObject.ToString());
    		}
    	}
    }
