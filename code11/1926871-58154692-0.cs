using( System.IO.StreamReader sr1 = new System.IO.StreamReader(args[1]))
                {
                    using( System.IO.StreamReader sr2 = new System.IO.StreamReader(args[2]))
                    {
                        string line1,line2;
                
                while ((line1 = sr1.ReadLine()) != null) 
                {
                    while ((line2 = sr2.ReadLine()) != null)
                    {
                        if(line1.Contains(line2))
                        {
                            found = true;
                            WriteLine("{0} exists!",line2);
                        }
                      
                        
                        if(found == false)
                        {
                            WriteLine("{0} does not exist!",line2);
                        }
                    }
                }
                    }
                }
