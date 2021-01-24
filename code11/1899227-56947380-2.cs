    static void Main(string[] args)
    {
        Dictionary<string, string> myList = new Dictionary<string, string>();
    
        myList.Add("Fruit", "Apple");
        //Inserting 1 before vegtable
        myList.Add("1Vegtable", "Potato");
        myList.Add("Vehicle", "Car");
    
        XElement ele = new XElement("root", myList.Select(kv => new XElement(kv.Key, kv.Value)));
    
        Console.WriteLine(ele);
    
        Console.Read();
    }
