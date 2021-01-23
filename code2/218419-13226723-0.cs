    public string ConvDate_as_str(string dateFormat)
        {
            try
            {
                char[] ch = dateFormat.ToCharArray();
                string[] sps = dateFormat.Split(' ');
                string[] spd = sps[0].Split('.');
                dateFormat = spd[0] + ":" + spd[1];
                if ((sps[1].ToUpper() != "PM") && (sps[1].ToUpper() != "AM"))
                {
                    return "Enter Correct Format like <5.12 pm>";
                }
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(dateFormat);
                string date = "";
                if (sps[1].ToUpper() == "PM")
                {
                    date = (dt.Hour + 12).ToString("00");
                }
                else
                    date = dt.Hour.ToString("00");
                return date + dt.Minute.ToString("00");
            }
            catch (Exception ex)
            {
                return "Enter Correct Format like <5.12 pm>";
            }
            
        }
