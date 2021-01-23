            string a=string.Join(",", FirstNames.ToArray());
            if (FirstNames.Count == 1)
                a.Replace(",", "");
            else if (FirstNames.Count == 2)
                a.Replace(",", " and ");
            else
            {
                int i = a.LastIndexOf(",");
                a = a.Substring(1, i) + a.Substring(i).Replace(",", " and ");
            }
