        public class ToDescription
        {
            public string ProductDescription { get; set; }
        }
        public class ActualObject
        {
            public string Product { get; set; }
            public List<ToDescription> to_Description { get; set; }
        }
        public class ChangedObject
        {
            public string Product { get; set; }
            public ToDescription to_Description { get; set; }
        }
