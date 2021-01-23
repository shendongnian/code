    public static List<Reading> Parser(this string[] str)
    {
        List<Reading> result = new List<Reading>();
        string meterNr = "";
        Reading reading;
        foreach (string s in str)
        {
            MatchCollection mc = Regex.Matches(s, "\\d+|\\((.*?)\\)");
            if (mc.Count == 1)
            {
               meterNr = mc[0].Value;
               continue;
            }
            reading = new Reading()
            { 
               MeterNr = meterNr,
               Date = mc[0].Value,
               Position = mc[1].Value,
               ItemDescription = mc[2].Value
            };
            if (mc.Count == 4) 
                reading.Consumption = mc[3].Value;
            result.Add(reading);            
        }
        return result;
    }
