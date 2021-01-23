    public virtual void Execute(JobExecutionContext context)
        { 
            SetYModemEvents();
            JobDataMap data = context.JobDetail.JobDataMap;
            string COM = data.GetString("COM");
            string BAUD = data.GetString("BAUD");
            string name = data.GetString("NAME");
            _yModem.AllowDisconnect = true;
            _connection.Port.PortName = COM;
            try
            {
                _connection.Port.BaudRate = int.Parse(BAUD);
            }catch(FormatException)
            {
                _connection.Port.BaudRate = 9600;
            }
            try
            {
                _connection.Port.Open();
            }catch(UnauthorizedAccessException ex)
            {
                //TODO Testen
                Trigger[] trArray = context.Scheduler.GetTriggersOfJob(context.JobDetail.Name, context.JobDetail.Group);
                if (trArray.Length >= 2)
                {
                    trArray.ToList().RemoveRange(1, 1);
                }
                JobDetail JB = context.JobDetail;
                Trigger delayTrigger = new SimpleTrigger(JB.Name + "_Delay", "DGroup", DateTime.UtcNow.AddMinutes(_delay), null, 1, TimeSpan.FromMinutes(_delay)); 
                JB.Name = JB.Name + "_Delay";
                JB.Group = "DGroup";
                context.Scheduler.ScheduleJob(context.JobDetail, delayTrigger);
                return;
            }
            
            
            _connection.Port.DataReceived += new SerialDataReceivedEventHandler(DataReceviedHandler);
            DeadManSwitch.Tick += new EventHandler(DeadManSwitch_Tick);
            DeadManSwitch.Start();
            if(Properties.Settings.Default.UseBubbels)
            {
                ReadOutHelperClass.ShowNotifiy(name, mynotifyicon);
            }
            //Starten der Auslesung
            _connection.Write(protocoll.ReadLoggerData(), 0, protocoll.ReadLoggerData().Length);
            DeadManSwitch.Interval = DeadManTimeOut;
        }
