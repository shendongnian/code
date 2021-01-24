	class Dog
	{
	}
	class Cat
	{
	}
	public static void Main()
	{
		Dog d = new Dog();
		var a = (object)d;
		Cat cutie = (Cat)a;
	}
