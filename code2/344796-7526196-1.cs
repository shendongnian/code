        public void Each_Tick(object o, EventArgs e)
        {
            //Other code
            if (entryPoint.commandWaitingFlag)
            {
                handleEntryPointCommands();
            }
        }
