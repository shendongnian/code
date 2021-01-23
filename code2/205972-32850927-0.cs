        static public string ToDigitsOnly(string input)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(input, "");
        }
        static private DateTime ConvertDateTimeToDate(string dateTimeString, String langCulture)
        {
          
            System.DateTime result;
         
            string[] dateString = dateTimeString.Split('/');
            try
            {
                if (langCulture != "en")
                {
                    int Year = Convert.ToInt32(ToDigitsOnly(dateString[2]));
                    int Month = Convert.ToInt32(ToDigitsOnly(dateString[1]));
                    int Day = Convert.ToInt32(ToDigitsOnly(dateString[0]));
                    result = new DateTime(Year, Month, Day, 00, 00, 00);
                }
               else
                {
                    int Year = Convert.ToInt32(dateString[2]);
                    int Month = Convert.ToInt32(dateString[0]);
                    int Day = Convert.ToInt32(dateString[1]);
                    result = new DateTime(Year, Month, Day, 00, 00, 00);
                }
            }
            catch
            {
                // last attempt 
                result = Convert.ToDateTime(dateTimeString, CultureInfo.GetCultureInfo("en-US"));
            }
            return result;
        }
