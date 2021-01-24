    public class Metadata{
        public class EntityModelMetadata { 
            [JsonIgnore] //or whatever you need
            public int Test {get; set;}
        }
        public class EntityModel2Metadata { 
            [XmlIgnore] //or whatever you need
            public int Test2 {get; set;}
        }
    }
