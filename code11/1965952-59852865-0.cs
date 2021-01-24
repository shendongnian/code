c#
using (var context = new MyContext())
{
    var list = context.Field
        .Include(f => f.Field2)    
        .ToList();    
    
    foreach (var field in list)
    {
        Console.WriteLine("Field Name: {0}", field.Name);
        foreach (var field2 in field.Field2)
        {
            Console.WriteLine("\tField 2 ID: {0}", field.Id);
        }
    }
}
[Entity framework Include][1]
  [1]: https://entityframework.net/when-to-use-include
