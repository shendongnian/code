protected override void OnStart(string[] args)
{
    if(Console.IsOutputRedirected)
    {
        Thread serviceThread = new Thread(new ThreadStart(StartMyApplicationAsync));
        serviceThread.Start();
    } else {
        StartMyApplicationAsync();
    }
}
This way when testing the applications with the `--debug` switch, it will respond/end to Ctrl+c
