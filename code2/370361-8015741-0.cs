     public class Child1 : Parent
     {     
           public Child1(string _var1, string _var2) 
           {
                this.var1 = _var1;
                this.var2 = _var2
           }
           public string var1 { get; set;}     
           public string var2 { get; set;} 
     }
     Activator.CreateInstance(typeof(Child1), new object[] { "var1", "var2" }); 
