    public class FamilyMember
    {
        public FamilyMember()
        {
            
        }
        public FamilyMember(string name, string age, string dob)
        {
            NAME =name;
            // etc etc
        }
    
        [XmlElement("NAME")]
        public string NAME { get; set; }
    
        [XmlElement("AGE")]
        public string AGE { get; set; }
    
        [XmlElement("DOB")]
        public string DOB { get; set; }
        }
    }
