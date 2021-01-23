        string Talk();
      }
       class Cat: ICreature
       {
          public string Talk()
          {
             Console.WriteLine("Meow!");
             return true
          }
       }
       class Dog: ICreature
       {
          public string Talk()
          {
             Console.WriteLine("Arf!");
             return true
          }
       }
       class Human: ICreature
       {
          public string Talk()
          {
             Console.WriteLine("Hello!");
             return true
          }
       }
