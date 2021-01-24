    public partial class Member
    {
       public virtual long Id { get; set; }
       public virtual List<Tenant> Tenants { get; set; }  //tables have fk relationship
    }
     public partial class Tenant
    {
       public virtual long Id { get; set; }
       public virtual List<Member> Members{ get; set; }  //tables have another fk relationship?
    }
