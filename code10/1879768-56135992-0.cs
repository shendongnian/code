c#
public class MyModel
{
    public string MyId
    {
        get => Column1_PK + Column2;
        set => ...
    }
    public string Column1_PK { get; set; }
    public string Column2 { get; set; }
}
protected override void OnModelCreating(ModelBuilder builder)
{
    builder.Entity<MyModel>()
        .HasKey(m => m.Column1_PK); // this seems to be the actual PK based on my understanding
    
    builder.Entity<MyModel>()
        .Ignore(m => m.MyId);
}
