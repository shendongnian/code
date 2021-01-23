            foreach (char x in s)
            {
               
                if (dic.ContainsKey(x) == true) 
                {
                    dic[x] += 1;
                }
                else
                {
                    dic.Add(x, 1);
                
                }
              
            }
            foreach (KeyValuePair<char, int> x in dic)
            {
                Console.WriteLine(x.Key + " " + x.Value);
            
            }
