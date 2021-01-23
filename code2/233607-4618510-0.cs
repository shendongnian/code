    static void T3()
            {
                var data = new List<Person>{ new Person("Bill Gates", 55), 
                                    new Person("Steve Ballmer", 54), 
                                    new Person("Steve Jobs", 55), 
                                    new Person("Scott Gu", 35)};
    
                System.Diagnostics.Stopwatch s1 = new System.Diagnostics.Stopwatch();
    
                s1.Start();
                // 1st approach
                data.Where(x => x.Age > 40).ToList().ForEach(x => x.Age++);
                s1.Stop();
    
                System.Diagnostics.Stopwatch s2 = new System.Diagnostics.Stopwatch();
    
                s2.Start();
                // 2nd approach
                data.ForEach(x =>
                {
                    if (x.Age > 40)
                        x.Age++;
                });
                s2.Stop();
    
                Console.Write("s1: " + s1.ElapsedTicks + " S2:" + s2.ElapsedTicks);
                data.ForEach(x => Console.WriteLine(x));
            }
