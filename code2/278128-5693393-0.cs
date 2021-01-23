        public class Template
        {        
            public Template(string methodToCall)
            {
                  this.GetType().InvokeMember(methodToCall,
                              BindingFlags.InvokeMethod,
                              null,
                              this,
                              null);
                
            }
            public void methodIWantToCall()
            {
                Console.WriteLine("I'm running the Method!");
            }
       }
