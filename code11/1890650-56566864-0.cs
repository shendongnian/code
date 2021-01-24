using System;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Gun g1 = new Gun(50);
            Gun g2 = (Gun) g1.Clone();
            if (g1 != g2)
                Console.WriteLine("These objects are not aliases");
            Console.ReadLine();
        }
    }
    class Gun : ICloneable
    {
        int bullets;
        public Gun(int bullets)
        {
            this.bullets = bullets;
        }
        public object Clone()
        {
            return new Gun(this.bullets);
        }
    }
}
