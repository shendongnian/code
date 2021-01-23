    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace ca1
    {
    
    public class A
    {
        public int retval(int x)
        {
            return x; 
        }
    }
   
   
    class Program
    {
       
        static void Main(string[] args)
        {
            string s ="retval";
            Type t = typeof(A);
            ConstructorInfo CI = t.GetConstructor(new Type[] {});
            object o = CI.Invoke(new object[]{});
            MethodInfo MI = t.GetMethod(s);
            object[] fnargs = new object[] {4};
            Console.WriteLine("Function retuned : " +MI.Invoke(o, fnargs).ToString());
            
          }
       }
    }
