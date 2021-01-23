    class MyEventLog : EventLog
    {
        public MyEventLog(string logName, string machineName)
            : base(logName, machineName)
        {
            base.EnableRaisingEvents = true;
            base.EntryWritten += MyEventLog_EntryWritten;
        }
    
        void MyEventLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            Console.WriteLine("Entry in {0} log.", base.Log);
            
            // Your code
        }
    }
