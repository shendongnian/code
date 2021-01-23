       public class SwitchCase : Dictionary<string,Action>
        {
            public void Eval(string key)
            {
                if (this.ContainsKey(key))
                  this[key]();
                else
                 this["default"](); 
            }
        }
    
    
        //Now, somewhere else
    
                var mySwitch = new SwitchCase
                {
                    { "case1",  ()=>Console.WriteLine("Case1 is executed") },
                    { "case2",  ()=>Console.WriteLine("Case2 is executed") },
                    { "case3",  ()=>Console.WriteLine("Case3 is executed") },
                    { "case4",  ()=>Console.WriteLine("Case4 is executed") },
                    { "default",()=>Console.WriteLine("Default is executed") },
                };
    
                mySwitch.Eval(c);
