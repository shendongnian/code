    //Doing it in a Using statement to properly dispose of the StreamReader
    using (StreamReader sr = new StreamReader(path)) 
                {
    
                    while (sr.Peek() > -1) 
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
