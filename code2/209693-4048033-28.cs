    static async void RestartPrinter()
    {
        Printer printer = GetPrinter();
        do
        {
            printer.Restart();
            printer = await printer.WaitUntilReadyAsync();
        } while (printer.HasFailed);
    }
