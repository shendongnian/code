           while ((chain = readFile.ReadLine()) != null)
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
           }
           readFile.Close();
