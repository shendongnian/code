public class Action 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    public virtual Result Result {get; set;} //just virtual here, as Action is the dependent and Result is the principal-- i.e. this Result isn't required
    public string Description {get; set;}
}
public abstract class Result
{
    //got rid of the Result_Id, since it's 1:1 the Action_Id can be the Key
    [Required, Key] //added "Key"
    public int Action_Id {get; set;}
    [ForeignKey("Action_Id")]
    public Action Action {get; set;} //removed this virtual, as Action is Required for Result, that makes Result the principal
    public string Comment {get; set;}
    public class Approved : Result
    {
        public string Thing {get; set;}
    }
    public class Rejected : Result
    {
        public string Stuff {get; set;}
    }
    public class Modified : Result
    {
        public string Whatever {get; set;}
    }
}
And here is the fluent API code from the context:
//this gave me TPCT like I wanted
modelBuilder.Entity<Approved>().Map(m =>
{
    m.MapInheritedProperties();
    m.ToTable("Approved");
});
modelBuilder.Entity<Rejected>().Map(m =>
{
    m.MapInheritedProperties();
    m.ToTable("Rejected");
});
modelBuilder.Entity<Modified>().Map(m =>
{
    m.MapInheritedProperties();
    m.ToTable("Modified");
});
//this defined the principal-dependent relationship I was missing
modelBuilder.Entity<Action>()
    .HasOptional(a => a.Result)
    .WithRequired(a => a.Action)
    .Map(x => x.MapKey("Action_Id"));
And then it worked! Hopefully this example can assist someone else.
