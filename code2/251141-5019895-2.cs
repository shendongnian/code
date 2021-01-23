    using System;
    using System.Diagnostics;
    using System.Security;
    
    class MainClass
    {
        public static void Main (string[] args)
        {
            // the SecurityElement constructor escapes the & all by itself 
            var xmlRoot =
                new SecurityElement("test","test &");
    
            // the & is escaped without SecurityElement.Escape 
            Console.WriteLine (xmlRoot.ToString());
            
            // this would throw an exception (the SecurityElement constructor
            // apparently can't escape < or >'s
            // var xmlRoot2 =
            //    new SecurityElement("test",@"test & > """);
            
            // so this text needs to be escaped before construction 
            var xmlRoot3 =
                new SecurityElement("test",EscapeXML(@"test & > """));
            Console.WriteLine (xmlRoot3.ToString());
            
        }
        
        private static string EscapeXML(string nodeText)
        {
            return (SecurityElement.IsValidText(nodeText))?
                nodeText :
                SecurityElement.Escape(nodeText);
        }
    }
 
