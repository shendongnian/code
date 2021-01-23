    [Serializable]
    [XmlRoot("RESY")]
    public class FamilyBlock: IXmlSerializable
    {
        public List<FamilyMember> FAMILYMEMBERS{ get; set; }
        public FamilyBlock()
        {
            
        }
        public FamilyBlock(string name, int age, DateTime? dob)
        {
            var familyMembers = new List<FamilyMember>  // etc etc
         ....
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var item in FAMILYMEMBERS)
            {
                writer.WriteElementString("NAME", item.NAME);
                writer.WriteElementString("AGE", item.AGE);
                writer.WriteElementString("DOB", item.DOB);
            }
        }
    }
