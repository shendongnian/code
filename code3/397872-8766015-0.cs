    using System;
    using System.ComponentModel;
    
    namespace ConsoleApplication1
    {
        internal class Metadata
        {
            [DisplayName("[BILL-FNAME]")]
            public string FName { get; set; }
        } 
        
        class Program
        {
            static void Main()
            {
                var memberInfo = typeof(Metadata).GetMember("FName")[0];
                var atrributes = memberInfo.GetCustomAttributes(false);
                Console.WriteLine(atrributes[0].GetType().Name);
            }
        }
    }
