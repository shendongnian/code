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
        public int ID { get; set; } //incremental ID 
        public int? ParentID { get; set; } // Parent incremental ID
        public ObjectType Type { get; set; } // The Object type
        public string ObjectID { get; set; } // Object ID defined in SSAS
        public string ObjectName { get; set; } // Object Name defined in SSAS
        public string Extension { get; set; } // The Object extension
        public string FolderPath { get; set; } // The Object related directory
        public string FolderName { get; set; } // The directory name
        public DateTime? FolderModifiedDate { get; set; } // The directory last modified date
        public string FolderIncremetalID { get; set; } // The Incremental Number mentioned in the directory name
        public string XMLFilePath { get; set; } // The Object related XML file
        public string XMLFileName { get; set; } // The XML file name
        public DateTime? XmlModifiedDate { get; set; } // The XML file last modified date
        public string XmlIncremetalID { get; set; }  // The incremental number mentioned in the XML file name      
        
        
    }
