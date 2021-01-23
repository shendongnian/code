     [AttributeUsage(AttributeTargets.Property)]
     public class ClassAttribute : Attribute
     {
       public String PropertyName;
       public String PropertyDescription;
     }
    // Property declaration
    [ClassAttribute(PropertyName = "Name", PropertyDescription = "Name")]
    public String Name { get; private set; }
    // Enumeration
      IEnumerable<PropertyInfo> PropertyInfos = t.GetProperties();
      foreach (PropertyInfo PropertyInfo in PropertyInfos)
      {
        if (PropertyInfo.GetCustomAttributes(true).Count() > 0)
        {
          PropertyInfo info = t.GetProperty(PropertyInfo.Name);
         }
       }
