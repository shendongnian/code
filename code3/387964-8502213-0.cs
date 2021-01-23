                 Dictionary<string, string> md1 = new Dictionary<string,string>();
                 Dictionary<string, Dictionary<string, string>> md2 = new Dictionary<string, Dictionary<string, string>>();
    
                 Stopwatch st = new Stopwatch();
                 
                 st.Start(); 
    
                 for (int i = 0; i < 2000000; i++)
                 {
                     md1.Add(i.ToString(), "blabla"); 
                 }
    
                 st.Stop();
    
                 Console.WriteLine(st.ElapsedMilliseconds);
    
                 st.Reset();
                 st.Start(); 
                 for (int i = 0; i < 2000000; i++)
                 {
                     md2.Add(i.ToString(), new Dictionary<string, string>()); 
                 }
                 st.Stop();
    
                 Console.WriteLine(st.ElapsedMilliseconds);
                 Console.ReadLine(); 
