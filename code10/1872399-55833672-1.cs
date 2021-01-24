    public class SSASObject
    {
        public enum ObjectType{
            Cube = 0,
            MeasureGroup = 1,
            Dimension = 2,
            Partition = 3,
            AggregationDesign = 4,
            MiningStructure = 5,
            Role = 6,
            DataSource = 7,
            DataSourceView = 8,
            Database = 9,
            Server = 10,
            Kpi = 11,
            Action = 12
        }
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public ObjectType Type { get; set; }
        public string ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string Extension { get; set; }
        public string FolderPath { get; set; }
        public string FolderName { get; set; }
        public DateTime? FolderModifiedDate { get; set; }
        public string FolderIncremetalID { get; set; }
        public string XMLFilePath { get; set; }
        public string XMLFileName { get; set; }
        public DateTime? XmlModifiedDate { get; set; }
        public string XmlIncremetalID { get; set; }        
        
        
    }
