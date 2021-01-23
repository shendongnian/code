    public static Dictionary<int,string> GetCombinations( this Enum enu)
        {
            var result = enu.GetType()
                            .GetFields()
                            .Where(f => f.Name != "value__")
                            .ToDictionary(f=>Convert.ToInt32(f.GetRawConstantValue()), f => f.Name());
            int max = Enum.GetValues(enu.GetType()).Cast<int>().Max() +1 ;
            int upperBound = Enum.GetValues(enu.GetType()).Cast<int>().Max() * 2;
           
            for (int i = max; i < upperBound; i++)
            {
                if (!result.ContainsKey(i))
                {
                    var newComb = string.Empty;
                    for (int j = i-1; j >= 0; j--)
                    {
                        if (result.ContainsKey(j))
                        {
                            newComb = newComb + result[j] + " | ";
                        }
                    }
                    newComb = newComb.Trim(new char[] {' ','|'});
                    result.Add(i, newComb);
                }
            }
            return result;
        }
