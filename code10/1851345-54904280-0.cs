    interface IProduct
    {
        string Id {get;}
    }
    class Cosmetic : IProduct
    {
     public string Id {get;}
    //Other members
    }
    class Parfume : IProduct
    {
     public string Id {get;}
    //Other members
    }
    
        public static class AppExtension
        {
            public static bool IsStyleValid<T>(this List<T> instance, string style)
      where T : IProduct
            {
                foreach (var item in instance)
                {
                    var matchNumbersInDecimal = Regex.IsMatch(item.Id, "^(\\d*\\.)\\d+");
                    var matchFullNumbers = Regex.IsMatch(item.Id, "^\\d+$");
                    var matchNumbersWithHalfs = Regex.IsMatch(item.Id, "^[1-9][0-9]*\\/[1-9][0-9]*");
    
                    if ((style == "decimal" && !matchNumbersInDecimal)
                        || (style == "full" && !matchFullNumbers)
                        || (style == "numbersWithHalfs" && !matchNumbersWithHalfs))
                    {
                        return false;
                    }
                }
    
                return true;
            }
        }
    static void Main(string[] args)
    {
        List<Cosmetics> cosmetics = GetData();
    
        bool x = cosmetics.IsStyleValid("decimal");
    }
