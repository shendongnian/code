    private class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
    // deserializes your JSON and creates a list of Person objects from it
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        // your JSON
        string json =
            "{\"lastUpdated\":\"16:12\",\"filterOut\":[],\"people\": " +
            "[{\"ID\":\"x\",\"Name\":\"x\",\"Age\":\"x\"},{\"ID\":\"x\",\"Name\":\"x\",\"Age\":\"x\"},{\"ID\":\"x\",\"Name\":\"x\",\"Age\":\"x\"}]," +
            "\"serviceDisruptions\":" +
            "{" +
            "\"infoMessages\":" +
            "[\"blah blah text\"]," +
            "\"importantMessages\":" +
            "[]," +
            "\"criticalMessages\":" +
            "[]" +
            "}" +
            "}";
            
        // deserialize from JSON to XML
        XDocument doc = JsonConvert.DeserializeXNode(json, "root");
            
        // iterate all people nodes and create Person objects
        IEnumerable<Person> people = from person in doc.Element("root").Elements("people")
                                     select new Person()
                                     {
                                         ID = person.Element("ID").Value,
                                         Name = person.Element("Name").Value,
                                         Age = person.Element("Age").Value
                                     };
            
        // this is just demonstrating that it worked
        foreach (Person person in people)
            Debug.WriteLine(person.Name);
    }
