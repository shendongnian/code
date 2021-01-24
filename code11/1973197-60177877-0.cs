    class Model
    {
        public int Id { get; set; }
        public Dictionary<string, List<ComplexType>> Values { get; set; }
        public string ToJson()
        {
            return
                $"{{" +
                $"\"{nameof(Id)}\":\"{Id}\"," +
                string.Join(",", Values.Select(x => $"\"{x.Key}\":" + Newtonsoft.Json.JsonConvert.SerializeObject(x.Value))) +
                $"}}";
        }
    }
