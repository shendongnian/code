    public class Example
    {
        public String Name { get; set; }
    }
    // 
    var i = @"{ ""Name"" : ""Eduardo Fonseca Bola\u00c3\u00b1os comparti\u00c3\u00b3 una publicaci\u00c3\u00b3n."" }";
    var jsonConverter = Newtonsoft.Json.JsonConvert.DeserializeObject(i);
    
    // Encode the string to UTF8
    byte[] bytes = Encoding.Default.GetBytes(jsonConverter.ToString());
    var myString = Encoding.UTF8.GetString(bytes);
    Console.WriteLine(myString);
    
    // Deserialize using class
    var sample = Newtonsoft.Json.JsonConvert.DeserializeObject<Example>(i);
    byte[] bytes = Encoding.Default.GetBytes(sample.Name);
    var myString = Encoding.UTF8.GetString(bytes);
    Console.WriteLine(myString);
