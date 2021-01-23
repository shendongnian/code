        private string MyLogFull;
        //this property will retreive last1000MyLogs but stores all logs 
        public string MyLog
        {
            get
            {
                return GetLast1000MyLogs();
            }
            set
            {
                this.MyLogFull = value;
            }
        }
        private string GetLast1000MyLogs()
        {
            string last1000MyLogs = "";
            if (!String.IsNullOrEmpty(MyLogFull))
            {
                last1000MyLogs = string.Join("\n", MyLogFull.Split('\n').Reverse().Take(1000).Reverse().ToList().ToArray());
            }
            else
            {
                last1000MyLogs = "";
            }
            return last1000MyLogs;
        }
        public string GetMyLogsExceptLast1000()
        {
            int TotalMyLogs = 0;
            string MyLogsExceptLast1000 = "";
            if (!String.IsNullOrEmpty(MyLogFull))
            {
                TotalMyLogs = MyLogFull.Split('\n').Length;
            }
            if (TotalMyLogs > 1000)
            {
                MyLogsExceptLast1000 = string.Join("\n", MyLogFull.Split('\n').Take(TotalMyLogs - 1000).ToList().ToArray());
            }
            return MyLogsExceptLast1000;
        }
    }
