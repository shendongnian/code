    <Application x:Class="WpfApplication1.App"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Startup="Application_Startup">
        <Application.Resources>
         
        </Application.Resources>
    </Application>
    namespace WpfApplication1
    {
        
        public partial class App : Application
        {
            private XmppClientConnection _client = new XmppClientConnection ( );
            private void Application_Startup(object sender, StartupEventArgs e)
            {
                var mainWindow = new Window1();
                mainWindow.Show();
            }
        }
    }
