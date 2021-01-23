    MyClass myClass = JsonConvert.DeserializeObject<MyClass>(your_json_string);
    [Serializable]
    public class MyClass
    {
        public string myVar {get; set;}
        etc.
    }
