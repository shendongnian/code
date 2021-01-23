    //instantiate new Hashtable
    Hashtable hashtable = new Hashtable();
    
    //create a class that would represent a value in the HashTable
    public class SomeObject
    {
        public string value1 { get; set;}
        public string value2 { get; set;}
    }
    //create a List that would store our objects
    List<SomeObject> list = new List<someObject>();
    //add new items to the created list
    list.Add(new SomeObject() 
                 { 
                     value1 = "test", 
                     value2 = "test1"
                 });
    list.Add(new SomeObject() 
                 {
                     value1 = "secondObject_value1" 
                     value2 = "secondObject_value2"
                 })
    
    //add key/value pairs to the Hashtable.
    hashTable.Add("1", list[0]);
    hashTable.Add("2", list[1]);
