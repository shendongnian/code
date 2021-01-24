    List<Animal> lstA = new List<Animal>();
    		lstA.Add(new Cat());
    		lstA.Add(new Dog());
    		foreach(Animal a in lstA)
    		{
    			Console.WriteLine("Type of {0}", a.GetType());
    		}
    abstract class Animal
    {}
    class Cat : Animal
    {}
    class Dog : Animal
    {}
