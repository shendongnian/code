cs
public class Person {
    public int Id { get; set }
    public string Name { get; set; }
}
So, if you have a query without `$select`, the IQueryable will generate a collection of Person, with all properties (id and name) in each item.
But, if you use a `$select=id` query, each item will have only the ID property and you cant Cast a dynamic type to a Person type.
In other words, you cant use `$select` and return a `List<UserInfoDto>`, you need to return a `List<dynamic>` without the Cast method, just like this:
cs
    var result = ops.ApplyTo(query) as IQueryable<dynamic>;
    return result.ToList();
