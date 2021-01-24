           chain = readFile.ReadLine();
           while (chain != null)
           {
               fields = chain.Split(breakUp);
               if (fields[0].Trim().Equals("Name"))
               {
                    name = fields[1].Trim();
               }
               else
               {
                   if (fields[0].Trim().Equals("Age"))
                   {
                        Age = fields[1].Trim();
                   }
                }
           chain = readFile.ReadLine(); // <--
           }
           readFile.Close();
