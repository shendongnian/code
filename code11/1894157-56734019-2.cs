csharp
MappingConfiguration.Global.Define(
   new Map<User>()
      .TableName("users")
      .PartitionKey(u => u.UserId)
      .ExplicitColumns()
      .Column(u => u.UserId, cm => cm.WithName("id")));
https://docs.datastax.com/en/developer/csharp-driver/3.10/features/components/linq/#configuring-mappings
In case you are using attribute-based mappings, you can set `ExplicitColumns` on the `TableAttribute`:
csharp
[Table("users", ExplicitColumns = true)]
public class User
{
  // ...
}
If you want to use most of the properties in your entity, while just ignoring few of them, you can also use `IgnoreAttribute`:
csharp
[Table("users")]
public class User
{
  // ...
  [Ignore]
  public string IgnoreMe { get; set; }
}
