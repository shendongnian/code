    public static bool IsValidDateTime(string dateTime)
            {
                long lCheck;
                dateTime = dateTime.Trim();
                //check if its valid integers
                bool status = long.TryParse(dateTime, out lCheck);
                //if its not valid long value or length does not conforms the format throw an exception or return false
                if (!status || dateTime.Length != 14)
                    throw new Exception("Input does not conforms yyyyMMddHHmmss fromat");
    
                try
                {
                   
                        DateTime.ParseExact(dateTime.ToString(), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception exp)
                {
                    return false;
                }
    
                //everything is well lets return true
                return true;
            }
