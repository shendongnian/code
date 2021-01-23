        public class Description {
        private int attribute_id;
        private string element_text;
        [XmlAttribute("id")]
        public int Id {
            get { return attribute_id; }
            set { attribute_id = value; }
        }
        [XmlText()]
        public string Text {
            get { return element_text; }
            set { element_text = value; }
        }
    }
