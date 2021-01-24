c#
public class MyModel
{
    public string MyId
    {
        get
        {
            if (Column1_PK != Column2)
            {
                // TODO: handle if values are not equal
            }
            else
            {
                return Column1_PK;
            }
        }
        set
        {
            Column1_PK = value;
            Column2 = value;
        }
    }
    public string Column1_PK { get; private set; }
    public string Column2 { get; private set; }
}
protected override void OnModelCreating(ModelBuilder builder)
{
    builder.Entity<MyModel>()
        .HasKey(m => m.Column1_PK); // this seems to be the actual PK based on my understanding
    
    builder.Entity<MyModel>()
        .Ignore(m => m.MyId);
}
