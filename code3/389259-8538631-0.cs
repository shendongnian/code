        static void Main()
        {
            Dog dog = new BullDog();
            BullDog bulldog = new BullDog();
    
            dog.Execute();
            bulldog.Execute();
        }
    
        class Dog
        {
            public virtual void Execute()
            {
                Console.WriteLine("Execute Dog");
            }
        }
        
        class BullDog : Dog
        {
            public new void Execute() // use new instead of override
            {
                Console.WriteLine("Execute BullDog");
            }
        }
