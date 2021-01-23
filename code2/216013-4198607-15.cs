    public static class Enum<T>
    {
      public static T ParseToEnumFlag(NameValueCollection source, string formKey)
      {
        //MVC 'helpfully' parses the checkbox into a comma-delimited list. We pull that out and sum the values after parsing it back into the enum.
        return (T)Enum.ToObject(typeof(T), source.Get(formKey).ToIEnumerable<int>(',').Sum());
      }
    }
