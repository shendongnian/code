    public class MyClass 
    {
        public int SomeNumber { get; set;}
    }
    
    foreach(KeyValuePair<string, MyClass> entry in myDict)
    {
        entry.Value.SomeNumber = 3; // is okay
        myDict[entry.Key] = new MyClass(); // is not okay
    }
