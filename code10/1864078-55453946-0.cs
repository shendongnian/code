                DateTime a = DateTime.Now;
                Console.WriteLine("Start Date: " +Convert.ToString(a));
                
                DateTime b = DateTime.Now.AddDays(5).AddHours(5);
                //b = b.ToUniversalTime();
                Console.WriteLine("End Date: " +Convert.ToString(b));
    
                TimeSpan result = b - a;
                
                //Your code goes here
                Console.WriteLine(Convert.ToString(result));
