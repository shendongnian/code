    [XmlRoot("form")]       
    public class Form       
    {       
        [XmlElement("question")]       
        public List<Question> Questions { get; set; }  
        
        [XmlElement("section")]     
        public List<Section> Sections {get; set;}
        public Form()       
        {       
              Questions = new List<Question>();       
              Sections = new List<Section>();
        }       
    }   
