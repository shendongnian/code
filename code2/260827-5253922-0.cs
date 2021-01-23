    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Reflection;
    
    public class MainClass{
    
       public static void Main(){
            Regex moneyR = new Regex(@"\$\d+\.\d{2}");
            string[] money = new string[] { "$0.99", 
                                            "$1099999.00", 
                                            "$10.25", 
                                            "$90,999.99", 
                                            "$1,990,999.99", 
                                            "$1,999999.99" };
            foreach (string m in money){
                Console.WriteLine(m);
                Console.WriteLine(moneyR.IsMatch(m));
            }
       }
    }
