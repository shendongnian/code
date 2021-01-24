    //We can use this statement.
    
    using System.Drawing;
    using System.Reflection;
    
     static void Main(string[] args)
            {
                try
                {       
                    Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);                
                }
                catch(ArgumentException ae) 
                {
                    //handle
                }     
