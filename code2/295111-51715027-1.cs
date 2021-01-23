    public static Dictionary<int,string> GetCombinations( this Enum enu)
        {
            var fields = enu.GetType()
                            .GetFields()
                            .Where(f => f.Name != "value__")
                            .DistinctBy(f=> Convert.ToInt32(f.GetRawConstantValue()));
            var result =fields.ToDictionary(f=>Convert.ToInt32(f.GetRawConstantValue()), f => f.Name());
            int max = Enum.GetValues(enu.GetType()).Cast<int>().Max();
            int upperBound = Enum.GetValues(enu.GetType()).Length * 2;
                       
            for (int i = max +1 ; i < upperBound-1; i++)
            {
                string s = Convert.ToString(i, 2).PadLeft(i-max,'0');
                Boolean[] bits = s.Select(chs => chs == '1' ? true : false)
                                 .Reverse()
                                 .ToArray();
                
                if (!result.ContainsKey(i))
                {
                    var newComb = string.Empty;
                    for (int j = 0; j < bits.Count(); j++)
                    {
                        if (result.ContainsKey(j))
                        {
                            newComb = newComb + result[j] + " | ";
                        }
                    }                                      
                    newComb = newComb.Trim(new char[] { ' ', '|' });
                    result.Add(i, newComb);                    
                }
            }
            return result;
