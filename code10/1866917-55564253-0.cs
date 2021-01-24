    public class Ministry
    {
       public int MinistryId { get; set; }
       public string Name { get; set; }
    
       public virtual MemberGroup MemberGroup { get; set; }
    }
    
    public class MemberGroup
    {
       public int MemberGroupId { get; set; }
       public string Name { get; set; }
    }
