csharp
public List<string> GetProperties(string model)
{
   var property = 
      this.GetType()
      .GetProperties()
      .Where(p=>p.Name == model)
      .FirstOrDefault();
   if(property == null) return IEnumerable.Empty<string>().ToList();
   return property
      .PropertyType
      .GetGenericArguments()[0]
      .GetProperties()
      .Select(p=>p.Name)
      .ToList();
}
