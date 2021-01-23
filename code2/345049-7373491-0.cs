    public class MemberToMembership
    {
        [Key] // maybe also DatabaseGenerated.Identity?
        public virtual int Id { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual decimal JoinFee { get; set; }
        public virtual decimal ChargePerPeriod { get; set; }
        public virtual decimal InductionFee { get; set; }
        public virtual int OptionId { get; set; }
        
        [ForeignKey("OptionId")]
        public virtual MembershipOption Option { get; set; }
    }
      
    public class MembershipOption
    {
        [Key]
        public virtual int Id { get; set; }
        
        public virtual string Period { get; set; }
        
        public virtual int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual MembershipType Type { get; set; }
        public virtual ICollection<MemberToMembership> MemberMap { get; set; }
    }
    public class MembershipType
    {
         [Key]
         public virtual int Id { get; set; }
         public virtual string Name { get; set; }
         public virtual ICollection<MembershipOption> Options { get; set; }
    }
