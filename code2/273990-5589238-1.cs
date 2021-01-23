    //many normal classes can be made xml serializable by adding [Serializable] at the top of the class
    [Serializable]
    private class ClassThing
    {
        public string Name { get; set; }
        public int Foos { get; set; }
    }
    //here we create the objects so you can access them later individually
    ClassThing thing1 = new ClassThing { Name = "name1", Foos = 1 };
    ClassThing thing2 = new ClassThing { Name = "name2", Foos = 2 };
    ClassThing thing3 = new ClassThing { Name = "name3", Foos = 3 };
    //this is an example of putting them in a list so you can iterate through them later.
    List<ClassThing> listOfThings = new List<ClassThing>();
    listOfThings.Add(thing1);
    listOfThings.Add(thing2);
    listOfThings.Add(thing3);
    //iteration example
    string combined = string.Empty;
    foreach (ClassThing thing in listOfThings)
    {
        combined += thing.Name;
    }
    //you could also have created them directly in the list, if you didnt need to have a reference for them individually, like this:
    listOfThings.Add(new ClassThing { Name = "name4", Foos = 4 });
    //and more advanced concepts like linq can also help you aggregate your list to make the combined string. the foreach makes the code more readable though. this gives the same result as the foreach above, ignore it if it confuses you :)
    string combined = listOfThings.Aggregate(string.Empty, (current, thing) => current + thing.Name);
    //Here is an example of how you could serialize the list of ClassThing objects into a file:
    using (FileStream fileStream = new FileStream("classthings.xml", FileMode.Create))
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ClassThing>));
        xmlSerializer.Serialize(fileStream, listOfThings);
    }
