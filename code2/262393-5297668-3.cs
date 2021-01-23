        public SetInt()
        {
            try
            {
                i = "OLAGH"; //This is bad!!!
                return i;
            }
            finally
            {
                // Cleanup.
            } 
        }
