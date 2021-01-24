    string str = "thisIsMyNameNishant";
                var queryvalue = str.Select(x =>
                {
                    if (char.IsUpper(x))
                        return "_" + x.ToString();
                         
                    else
                        return x.ToString();
                });
    
                foreach (string c in queryvalue)
                {
                    Console.Write(Convert.ToString(c));
                }
