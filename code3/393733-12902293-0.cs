    public static void CheckBadNames(ref string[] parts)
        {
            string[] BadName = new string[] {"LIFE", "ESTATE" ,"(",")","-","*","AN","LIFETIME","INTREST","MARRIED",
                                             "UNMARRIED","MARRIED/UNMARRIED","SINGLE","W/","/W","THE","ET",
                                             "ALS","AS", "TENANT" };
            List<string> list = new List<string>(BadName); //convert array to list
            foreach(string part in list)
            {
                if (BadName.Any(s => part.ToUpper().Contains(s)))
                {
                    list.Remove(part);
                }
            }
            parts = list.ToArray(); // convert list back to array
        }
