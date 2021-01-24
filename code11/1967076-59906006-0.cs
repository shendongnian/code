    class Property { 
        private bool enabled = false;
        private int numberOfEnabledReadings = 0;
        public bool Enabled {
            get
            {
                //Do some processing (in this case counting the number of accecess)
                numberOfEnabledReadings++;
                return enabled;
            }
            set
            {
                enabled = value;
                //Update GUI
            }
        }
    
    }
