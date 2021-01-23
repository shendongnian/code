    public List<string> generateIdentifiers2(int quantity)
            {
                var uniqueIdentifiers = new List<string>(quantity);
                while (uniqueIdentifiers.Count < quantity)
                {
                    var sb = new StringBuilder();
                    sb.Append(random.Next(11, 100));
                    sb.Append(" ");
                    sb.Append(random.Next(11, 100));
                    sb.Append(" ");
                    sb.Append(random.Next(11, 100));
    
                    var id = sb.ToString();
                    id = new string(id.ToList().ConvertAll(x => x == '0' ? char.Parse(random.Next(1, 10).ToString()) : x).ToArray());
    
                    if (!uniqueIdentifiers.Contains(id))
                    {
                        uniqueIdentifiers.Add(id);
                    }
                }
                return uniqueIdentifiers;
            }
