    class AssemblyLoadTest {
    
       public static void Main() 
       {
          // subscribe to event
          AppDomain.CurrentDomain.AssemblyLoad += new                                
                AssemblyLoadEventHandler(MyAssemblyLoadEventHandler);
    
          // continue working
    
       }
    
       // will fire once an assembly is loaded
       static void MyAssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args) 
       {
           // your custom code here
           // you can check loaded assembly from args.LoadedAssembly.FullName
           ....
       }
    }
