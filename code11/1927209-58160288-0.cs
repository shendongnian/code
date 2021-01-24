        public class Notes
        {
            [XmlArray("ArrayOfArrayOfNote")]
            [XmlArrayItem("ArrayOfNote")]
            public NoteBook[] noteBook { get; set; } 
            public string Title { get; set; }
        }
