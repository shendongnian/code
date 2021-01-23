        public SetInt()
        {
            try
            {
                i = "OLAGH"; //This is bad!!!
                return i;
            }
            catch (FailException ex)
            {
                return FAIL;
            } 
        }
