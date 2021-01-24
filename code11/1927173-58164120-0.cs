csharp
public class MyEntity : IEntity
{
    // make sure:
    public int Id { get; set; }
    // or:
    [Key]
    public int SomeProperty { get; set; }
}
