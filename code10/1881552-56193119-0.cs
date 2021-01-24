    public class MyClass
    {
        public string id_menu { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public List<string> my_list {get; set; }
    }
    var result = JsonConvert.DeserializeObject<MyClass>(json);
