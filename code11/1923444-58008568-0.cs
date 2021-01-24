c#
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    Resources.MergedDictionaries.Clear();
    Resources.MergedDictionaries.Add(GetMainDictionary());
    Resources.MergedDictionaries.Add(GetLightThemeDictionary());
    LoadTheme(AppTheme.Light);
    var w = new MainWindow();
    ShutdownMode = ShutdownMode.OnMainWindowClose;
    MainWindow = w;
    w.Show();
}
And I uncommented the 2 comments (that make use of the Dispatcher):
c#
internal void LoadTheme(AppTheme t)
{
    Dispatcher.BeginInvoke(new Action(() =>
    {
        [...]
    }), System.Windows.Threading.DispatcherPriority.Normal);
}
