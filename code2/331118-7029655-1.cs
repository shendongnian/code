        void Main()
        {
        	var date1 = new DateTime(2011, 8, 11, 16, 59, 00);
            date1.Round15().Dump();
            
            var date2 = new DateTime(2011, 8, 11, 17, 00, 02);
            date2.Round15().Dump();
            
            var date3 = new DateTime(2011, 8, 11, 17, 01, 23);
            date3.Round15().Dump();
        }
        
    public static class Extentions
    {
        public static DateTime Round15(this DateTime value)
        {   
            // Take care of seconds
            if (value.Second % 60 != 0)
                value = value.AddSeconds(60 - value.Second % 60);
            
            // Round UP to 15 minutes
            if (value.Minute % 15 != 0)
                value = value.AddMinutes(15 - value.Minute % 15);
                
            return value;
        }
    }
