    //Compiler Microsoft (R) .NET Framework 4.5
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    //Overriding & overloading
    
    namespace polymorpism
    {
        public class Program
        {
            public static void Main(string[] args)
            {
    
                drowButn calobj = new drowButn();
    
                BtnOverride calobjOvrid = new BtnOverride();
    
                Console.WriteLine(calobj.btn(5.2, 6.6).ToString());
    
                //btn has compleately overrided inside this calobjOvrid object
                Console.WriteLine(calobjOvrid.btn(5.2, 6.6).ToString());
                //the overloaded function
                Console.WriteLine(calobjOvrid.btn(new double[] { 5.2, 6.6 }).ToString());
    
                Console.ReadKey();
            }
        }
    
        public class drowButn
        {
    
            //same add function overloading to add double type field inputs
            public virtual double btn(double num1, double num2)
            {
    
                return (num1 + num2);
    
            }
    
    
        }
    
        public class BtnOverride : drowButn
        {
    
            //same add function overrided and change its functionality 
            //(this will compleately replace the base class function
            public override double btn(double num1, double num2)
            {
                //do compleatly diffarant function then the base class
                return (num1 * num2);
    
            }
    
            //same function overloaded (no override keyword used) 
            // this will not effect the base class function
    
            public double btn(double[] num)
            {
                double cal = 0;
    
                foreach (double elmnt in num)
                {
    
                    cal += elmnt;
                }
                return cal;
    
            }
        }
    }
