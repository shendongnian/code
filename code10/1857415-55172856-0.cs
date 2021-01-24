    [Table("GroupMembers")]
    public class GroupMember
    {
        [Key, ForeignKey("Group"), Column(Order = 1)]
        public int GroupCompanyID { get; set; }
    
        [Key, ForeignKey("Company"), Column(Order = 2)]
        public int MemberCompanyID { get; set; }
    
        [Column("MemberCode")]
        public string MemberCompanyCode { get; set; }
    
        [Column("RegionID")]
        public int RegionId { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Group Group { get; set; }
    }
    
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string Name { get; set; }
        // ...
    }
    
    [Table("Groups")]
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        // ...
    }
