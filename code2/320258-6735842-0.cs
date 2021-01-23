    public class Case
    {
        [XmlIgnore] public string ID;
        [XmlIgnore] public string JuristictionID;
        [XmlElement("CaseTrackingID")]
        public CaseTrackingID SerializedCaseTrackingID
        {
          get 
          { 
              return new CaseTrackingID 
              { 
                  ID = this.ID, 
                  JuristictionID = this.JuristictionID,
              }; 
          }
          set 
          { 
              this.ID = value.ID; 
              this.JuristictionID = value.JuristictionID;
          }
        }
    }
    public class CaseTrackingID 
    {
        [XmlElement("ID")]
        public string ID;
        [XmlElement("IDJurisdictionText")]
        public string JurisdictionID;
    }
