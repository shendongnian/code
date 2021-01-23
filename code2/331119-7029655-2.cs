    void Main()
    {
    	var date1 = new DateTime(2011, 8, 11, 16, 59, 00);
        date1.Round15().Dump();
        
        var date2 = new DateTime(2011, 8, 11, 17, 00, 02);
        date2.Round15().Dump();
        
        var date3 = new DateTime(2011, 8, 11, 17, 01, 23);
        date3.Round15().Dump();
        
        var date4 = new DateTime(2011, 8, 11, 17, 00, 00);
        date4.Round15().Dump();
    }
    
    public static class Extentions
    {
        public static DateTime Round15(this DateTime value)
        {   
            var ticksIn15Mins = TimeSpan.FromMinutes(15).Ticks;
            
            return (value.Ticks % ticksIn15Mins == 0) ? value : new DateTime((value.Ticks / ticksIn15Mins + 1) * ticksIn15Mins);
        }
    }
