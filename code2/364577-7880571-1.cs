    using System;
    
    class Dog
    {
       public virtual void Bark()
       {
           Console.WriteLine("RUFF!");
       }
    }
    
    class GermanShepard:Dog
    {
        public override void Bark()
        {
           Console.WriteLine("Rrrrooouuff!!");
        }
    }
    
    class Chiuaua:Dog
    {
        public override void Bark()
        {
             Console.WriteLine("ruff");
        }
    }
    class InclusionExample
    {
         public static void Main()
         {
            Dog MyDog=new Dog();    
            MyDog=new GermanShepard();
            MyDog.Bark(); // prints Rrrrooouuff!!
    
            MyDog=new Chiuaua();
            MyDog.Bark(); // prints ruff;
        }
    }
