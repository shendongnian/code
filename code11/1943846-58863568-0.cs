        public class IdComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                int xYear = GetYear(x);
                int yYear = GetYear(y);
                if (xYear != yYear)
                {
                    return xYear.CompareTo(yYear);
                }
    
                int xMonth = GetMonth(x);
                int yMonth = GetMonth(y);
                if (xMonth != yMonth)
                {
                    return xMonth.CompareTo(yMonth);
                }
    
                int xDay = GetDay(x);
                int yDay = GetDay(y);
                if (xDay != yDay)
                {
                    return xDay.CompareTo(yDay);
                }
    
                int xUniqueId = GetUniqueIdentifier(x);
                int yUniqueId = GetUniqueIdentifier(y);
                if (xUniqueId != yUniqueId)
                {
                    return xUniqueId.CompareTo(yUniqueId);
                }
    
                return 0;
            }
    
            private static int GetYear(string id)
            {
                return Int32.Parse(id.Substring(4, 2));
            }
    
            private static int GetMonth(string id)
            {
                return Int32.Parse(id.Substring(2, 2));
            }
    
            private static int GetDay(string id)
            {
                return Int32.Parse(id.Substring(0, 2));
            }
    
            private static int GetUniqueIdentifier(string id)
            {
                return Int32.Parse(id.Substring(6));
            }
        }
