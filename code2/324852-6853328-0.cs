    public class Dog
    {
        int weight;
        int name;
        public static void main (string[] args)
        {
            Dog myDog = new Dog();
            myDog.weight = 15;
            myDog.name = "Fido";
            Console.WriteLine("MyDog Name: {0} Weight: {1}", myDog.weight, myDog.name);
        
            Dog bigDog = new Dog();
            bigDog.weight = 100;
            bigDog.name = "Beethoven";
        
            Console.WriteLine("BigDog Name: {0} Weight: {1}", bigDog.weight, bigDog.name);
        }
    }
