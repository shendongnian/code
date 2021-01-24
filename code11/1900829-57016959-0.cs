    Object[] obj = new object[5];
    
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i] = "Diako" + i;
                }
    
                var q = obj.First(a => a.ToString().Equals("Diako1")).ToString();
                Console.WriteLine(q);
