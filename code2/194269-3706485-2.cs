    class Person {
    
    	int age;
    	string name;
    
    	public int Age { get { return age; } }
    	public string Name { get { return name; } }
    }
    
    // ...
    
    using Mono.Reflection;
    using System.Reflection;
    
    // ...
    
    Person person = new Person (27, "jb");
    PropertyInfo nameProperty = typeof (Person).GetProperty ("Name");
    FieldInfo nameField = nameProperty.GetBackingField ();
    nameField.SetValue (person, "jbe");
