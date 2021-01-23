        public string Time_In_Absolute(double time)
        {
            time = Math.Round(time, 2);
            string[] timeparts = time.ToString().Split('.');                        
            timeparts[1] = "." + timeparts[1];
            double Minutes = double.Parse(timeparts[1]);            
            Minutes = Math.Round(Minutes, 2);
            Minutes = Minutes * (double)60;
            return string.Format("{0:00}:{1:00}",timeparts[0],Minutes);
            //return Hours.ToString() + ":" + Math.Round(Minutes,0).ToString(); 
        }
