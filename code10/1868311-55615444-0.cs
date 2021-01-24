    public class SQLToData
    {
        public SQLToDataDataSource DataSource { get; set; }
        [XmlArray("PreProcessors")]
        [XmlArrayItem("PreProcessor")]
        public SQLToDataPreProcessor[] PreProcessors { get; set; }
        public string SQL { get; set; }
        public string ReturnType { get; set; }
    }
