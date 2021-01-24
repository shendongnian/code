    public abstract class Animal
    {
         public abstract string Talk();
    }
    public class Dog : Animal
    {
         public string Talk(){
             return "Bark";
         }
    }
    //cat class : Animal
    //elephant class : Animal
    Animal a = GetSomeRandomAnimal();
    switch (a) {
        case Dog d:
            Console.WriteLine($"The dog says {d.Talk()}");
        case Cat c:
            Console.WriteLine($"The cat says {c.Talk()}");
         //etc
    }
    
