    int count = 10000000;
                object [] a = new object[count];
    
                Stopwatch s1 = Stopwatch.StartNew();
                for (long i = 0; i < count; i++)
                    a[i] = new object();
                s1.Stop();
    
                Stopwatch s2 = Stopwatch.StartNew();
                for (int i = 0; i < count; i++)
                    a[i] = new object();
                s2.Stop();       
    
               
    
                Debug.WriteLine(s1.ElapsedTicks + "  " + s2.ElapsedTicks);
