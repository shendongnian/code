    [Serializable()]
    public class T
    {
        public int Id {get; set;}
        public string property1 {get; set;}
        public string property2 {get; set;}
    }
    ...
    List<T> data = new List<T>()
    
    ... // populate the list
    //create the serialiser to create the xml
    XmlSerializer serialiser = new XmlSerializer(typeof(List<T>));
 
    // Create the TextWriter for the serialiser to use
    TextWriter filestream = new StreamWriter(@"C:\output.xml");
    //write to the file
    serialiser.Serialize(filestream , data);
 
    // Close the file
    filestream.Close();
    
