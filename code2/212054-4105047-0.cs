     delegate int MyOwnDeletage(string d);
        class Program
        {
    
            static int Work(string s) { return s.Length; }
    
            static void Main(string[] args)
            {
    
                //  Func<string, int> method = Work; 
                MyOwnDeletage method =Work;
                    
                  IAsyncResult cookie = method.BeginInvoke ("test", null, null); 
                  // 
                  // ... here's where we can do other work in parallel... 
                  // 
                  int result = method.EndInvoke (cookie); 
                  Console.WriteLine ("String length is: " + result); 
            }
        }
