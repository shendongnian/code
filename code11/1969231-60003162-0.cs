    public class RootObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string size { get; set; }
        public string Company { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
    }
    var rt = JsonConvert.DeserializeObject<List<RootObject>>(www.text);
