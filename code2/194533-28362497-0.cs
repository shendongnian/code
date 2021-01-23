        public override void Init()
        {
            base.Init();
            lock (_initialisationLockObject)
            {
                BeginRequest -= Global_BeginRequest;
                BeginRequest += Global_BeginRequest;
            }
        }
