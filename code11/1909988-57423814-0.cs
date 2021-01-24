c#
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
		var startupView = new G_Hoover.Views.BrowserView.xaml();
		startupView.ShowDialog();
		
		base.OnStartup(e);
    }
}
