    string inputString = "/Test1/Test2";
                string[] stringSeparators = new string[] { "/Test1/"};
                string[] result;
                result = inputString.Split(stringSeparators,
                          StringSplitOptions.RemoveEmptyEntries);
               
                    foreach (string s in result)
                    {
                        Console.Write("{0}",s);
                        
                    }
                
    
    OUTPUT : Test2
