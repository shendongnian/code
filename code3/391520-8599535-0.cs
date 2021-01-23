    public class Person
    {
            private string name;
    
            public Person()
            {
                name = "John";
            }
    
            public Person(string name)
                : this() // call other constructor
            {
                // this is used to qualify the field
                // “name” is hidden by parameter
                this.name = name;
            }
    
            public string Name
            {
                get { return name; }
            }
    
            private void sayHi()
            {
                Console.WriteLine("Hi");
                Foo.SayName(this); //use this to pass current object 
            }
    
            public void Speak()
            {
                this.sayHi(); // use this to refer to an instance method
                Console.WriteLine("Want to come up and see my etchings? ");
            }
        }
    class Foo 
    {
    	public static void SayName(Person person)
    	{
    		Console.WriteLine("My name is  {0}", person.Name);
    	}
    }
