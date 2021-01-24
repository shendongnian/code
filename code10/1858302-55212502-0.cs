    public class Example
    {
        public String Name { get; set; }
    }
    // 
    var i = @"{ ""Name"" : ""Eduardo Fonseca Bola\u00c3\u00b1os comparti\u00c3\u00b3 una publicaci\u00c3\u00b3n."" }";
    var jsonConverter = Newtonsoft.Json.JsonConvert.DeserializeObject(i);
    Console.WriteLine(jsonConverter.ToString());
    //
    var sample = Newtonsoft.Json.JsonConvert.DeserializeObject<Example>(i);
    Console.WriteLine(sample.Name);
