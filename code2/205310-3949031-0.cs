    [DataContract]
    public class Company : BaseEntity
    {
        #region Constructors
        public Company()
        {
    
        }
    
        public Company(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        #endregion
    
        #region Properties
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<Industry> IndustryList { get; set;}
        #endregion
    
    }
