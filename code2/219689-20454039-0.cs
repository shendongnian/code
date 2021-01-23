        public int CauseError
        {
            get 
            {                
                Debugger.NotifyOfCrossThreadDependency();
                return 5;
            }
        }
