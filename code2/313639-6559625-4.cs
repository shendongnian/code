        using Microsoft.VisualBasic.ApplicationServices;
        //omitted namespace
        public class MyApp : WindowsFormsApplicationBase {
            private static MyApp _myapp;
    
            public static void Run( Form startupform ) {
                _myapp = new MyApp( startupform );
                
                _myapp.StartupNextInstance += new Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventHandler( _myapp_StartupNextInstance );
                _myapp.Run( Environment.GetCommandLineArgs() );
            }
    
            static void _myapp_StartupNextInstance( object sender, Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e ) {
                //e.CommandLine contains the new commandline arguments
                // this is where you do what you want with the new commandline arguments
                // if you want it the window to come to the front:
                e.BringToForeground = true;
            }
    
            private MyApp( Form mainform ) {
                this.IsSingleInstance = true;
                this.MainForm = mainform;
            }
        }
