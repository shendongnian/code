    class Foo 
    {  
        // with “this” modifiler we can use it like instance method of Person
    	public static void SayName(this Person person) 
    	{
    		Console.WriteLine(“My name is  {0}”, person.Name);
    	}
    }
