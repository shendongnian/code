using System;
using System.Collections.Generic;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Gun g1 = new Gun(50);
            g1.addModification("Scope");
            Gun g2 = (Gun) g1.Clone();
            if (g1 != g2)
                Console.WriteLine("These objects are not aliases");
            Console.WriteLine(g1);
            Console.WriteLine(g2);
            Console.ReadLine();
        }
    }
    class Gun : ICloneable
    {
        int bullets;
        List<object> modifications;
        public Gun(int bullets)
        {
            this.bullets = bullets;
            modifications = new List<object>();
        }
        public void addModification(object o)
        {
            modifications.Add(o);
        }
        public override string ToString()
        {
            return "Bullets: " + bullets + " Modifications: " + modifications[0];
        }
        public object Clone()
        {
            Gun clone = new Gun(this.bullets);
            foreach (object o in this.modifications)
                clone.modifications.Add(o);
            return clone;
        }
    }
}
