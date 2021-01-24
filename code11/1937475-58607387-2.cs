 c#
private void Application_Startup(object sender, StartupEventArgs e)
{
    ...    
    if(e.Args.Length > 1)
    {
		var filename = e.Args[1]);
    }
    ...
}
