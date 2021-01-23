    [Serializable]
    [XmlRoot("FAMILY")]
    public class FamilyBlock : IXmlSerializable
    {
       [XmlElement("NAME")]
       public List<string> NAME { get; set; }
       [XmlElement("AGE")]
       public List<int> AGE { get; set; }
       [XmlElement("DOB")]
       public List<DateTime?> DOB { get; set; }
    
       public FamilyBlock(string name, int age, DateTime? dob)
       {
          NAME = name;
          AGE = age;
          DOB = dob;
       }
    
       public void WriteXml(XmlWriter writer)
       {
          for (int i = 0; i < this.NAME.Count; i++)
          {
              writer.WriteElementString("NAME ", this.NAME[i]);
              writer.WriteElementString("AGE", this.AGE[i]);
              writer.WriteElementString("DOB", this.DOB[i]);
          }
                
       }
    }
