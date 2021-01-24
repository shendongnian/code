    if (Environment.GetCommandLineArgs().Count() > 1)
    {
        EventHandler handler = null;
        handler = async (sender, e) =>
        {
            Application.Idle -= handler;
            using (MyCustomConsole mcc = new MyCustomConsole())
            {
                await mcc.Run();
            }
            Application.ExitThread();
        };
        Application.Idle += handler;
        Application.Run(); // Begins running a standard application message
                           // loop on the current thread, without a form.
    }
