    public class X
    {
        [XmlElement()]
        public string Prop
        {
            get;
            set;
        }
    
        [XmlAttribute("Prop")]
         public string Prop1
        {
            get { return Prop; }
            set 
            {
                 if (!string.IsNullOrEmpty(value))
                 {
                      Prop = value;
                 }
            }
        }
    }
