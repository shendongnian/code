using System;
using System.Collections.Generic;
namespace Rextester
{
    public abstract class Base {
        public abstract void show();
    }
    public class Dep1: Base {
        public override void show() {
            Console.WriteLine("Dep1");
        }
    }
    public class Dep2: Base {
        public override void show() {
            Console.WriteLine("Dep2");
        }
    }
    
    public delegate Base Maker();
    
    public class Program
    {
       
        public static Base MakeDep1() { 
            return new Dep1(); 
        }
        public static Base MakeDep2() { 
            return new Dep2(); 
        }
        
        static Maker[] makers = new Maker[] {MakeDep1, MakeDep2};
        
        static Random rand = new Random();
        
        public static Base MakeRandom() { 
            return makers[rand.Next(makers.Length)](); 
        }
        public static void Main(string[] args)
        {
            List<Base> objs = new List<Base>();
            
            // build a list of "random-generated" objects
            for (int i=0; i<10; ++i) {
                objs.Add(MakeRandom());
            }
            
            foreach (Base obj in objs) {
                obj.show();
            }
        }
    }
}
For the running demo see https://rextester.com/NAAUJ16900
