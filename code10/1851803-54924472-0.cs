    using System;
    using System.Drawing;         //For Icon
    using System.Reflection;      //For Assembly
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    //Gets the icon associated with the currently executing assembly
                    //(or pass a different file path and name for a different executable)
                    Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);                
                }
                catch(ArgumentException ae) 
                {
                    //handle
                }           
            }
        }
    }
