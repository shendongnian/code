      public static DateTime test1(this DateTime d, string inputType)
        {
            if (inputType.Contains("DD"))
            {
                d = d.AddDays(Convert.ToInt32(inputType.Replace("DD", "")));
            }
            if (inputType.Contains("MM"))
            {
                d = d.AddMonths(Convert.ToInt32(inputType.Replace("MM", "")));
            }
            return d;
        }
