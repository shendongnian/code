public class Dog
{
    public int? Age { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float? Weight { get; set; }
    public int IgnoredProperty { get { return 1; } }
}
var guid = Guid.NewGuid();
var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });
If you add [Dapper.Contrib](https://github.com/StackExchange/Dapper/tree/master/Dapper.Contrib) you don't even need to write the query if you want all records. 
public class Car
{
    public int Id { get; set; } // Works by convention
    public string Name { get; set; }
}
(...)
var cars = connection.GetAll<Car>();
