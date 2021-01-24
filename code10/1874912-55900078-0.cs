               List<int> Array = new List<int>(); // must be intalized otherwise you will get null exception
    
                using (StreamReader SR = new StreamReader("Data.Txt")) //to prevent memorey leaks
                {
                   
                    while (!SR.EndOfStream)
                    {  
                        Array.Add(int.Parse(SR.ReadLine()));                     
    
                    } 
                }   
                 
                Console.WriteLine("ARRAY BEFORE SORTING");
    
                for (int x = 0; x <= Array.Count - 1; x++)
                {
                    Console.WriteLine(Array[x]);
                }   
    
                Console.ReadLine();
