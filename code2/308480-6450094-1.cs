    public void LogUpdate(string LogMessage)
    {
        Console.WriteLine("Entering");
        if (listBox_Output.Dispatcher.CheckAccess())
        {
            listBox_Output.Dispatcher.Invoke(new LogUpdateCallBack(delegate
            {
                listBox_Output.Items.Add(LogMessage);
            }));
            Console.WriteLine(LogMessage);
        }
    }
