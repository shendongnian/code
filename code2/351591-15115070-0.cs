    public class jsTreeModel
    {
        public string Data { get; set; }
        public JsTreeAttribute Att { get; set; }
        public string State { get; set; }
        [JsonIgnore]
        public List<jsTreeModel> Children { get; set; }
    }
