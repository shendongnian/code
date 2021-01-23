    class MyBaseClass: DynamicObject
    {
        // usefull functionality
    }
    class MyClass: MyBaseClass
    {
        Dictionary<string, object> dynamicProperties = new Dictionary<string, object>();
        override bool TryGetMember(...)
        {
           // read the value of the requested property from the dictionary
           // fire any events and return
        }
        override bool TrySetMember(...)
        {
           // set the value of the requested property to the dictionary
           // if the property does not exist,
           // add it to the dictionary (compile time dynamic property naming)
           // fire any events
        }
        override bool TryInvoke(...)
        {
           // check what method is requested to be invoked
           // is it "AddProperty"??
           // if yes, check if the first argument is a string
           // if yes, add a new property to the dictionary
           // with the name given in the first argument (runtime dynamic property naming)
           // if there is also a second argument of type object,
           // set the new property's value to that object.
           // if the method to be invoked is "RemoveProperty"
           // and the first argument is a string,
           // remove from the Dictionary the property
           // with the name given in the first argument.
         
           // fire any events
        }
    }
    // USAGE
    static class Program
    {
        public static void Main()
        {
            dynamic myObject = new MyClass();
            
            myObject.FirstName = "John"; // compile time naming - TrySetMember
            Console.WriteLine(myObject.FirstName); // TryGetMember
            myObject.AddProperty("Salary");  // runtime naming (try invoke "AddProperty" with argument "Salary")
            myObject.Salary = 35000m;
            Console.WriteLine(myObject.Salary); // TryGetMember
            myObject.AddProperty("DateOfBirth", new DateTime(1980,23,11)); // runtime naming (try invoke "AddProperty" with fisrt argument "DateOfBirth" and second argument the desired value)
            Console.WriteLine(myObject.DateOfBirth); // TryGetMember
            myObject.RemoveProperty("FirstName"); // runtime naming (try invoke "RemoveProperty" with argument "FirstName")
            Console.WriteLine(myObject.FirstName); // Should print out empty string (or throw, depending on the desired bahavior) because the "FirstName" property has been removed from the internal dictionary.
           
        }
    }
