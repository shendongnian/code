    public static Dictionary<int,string> GetCombinations( this Enum enu)
        {
            var fields = enu.GetType()
                            .GetFields()
                            .Where(f => f.Name != "value__")
                            .DistinctBy(f=> Convert.ToInt32(f.GetRawConstantValue()));
            var result =fields.ToDictionary(f=>Convert.ToInt32(f.GetRawConstantValue()), f => f.Name);
            int max = Enum.GetValues(enu.GetType()).Cast<int>().Max();
            int upperBound = max * 2;
                       
            for (int i = max + 1 ; i <= upperBound ; i++)
            {
                string s = Convert.ToString(i, 2).PadLeft(i-max,'0');
                Boolean[] bits = s.Select(chs => chs == '1' ? true : false)
                                 .Reverse()
                                 .ToArray();
                
                if (!result.ContainsKey(i))
                {
                    var newComb = string.Empty;
                    for (int j = 1; j < bits.Count(); j++)
                    {
                        var idx = 1 << j;
                        if (bits[j] && result.ContainsKey(idx))
                        {
                            newComb = newComb + result[idx] + " | ";
                        }
                    }                                      
                    newComb = newComb.Trim(new char[] { ' ', '|' });
                    if (!result.ContainsValue(newComb) && !string.IsNullOrEmpty(newComb))
                    {
                        result.Add(i, newComb);
                    }                    
                }
            }
            return result;
