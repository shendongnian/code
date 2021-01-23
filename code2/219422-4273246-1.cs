    public class SpecialClass
    {
      ***snip
      public static IEnumerable<SpecialClass> GetAllClasses(XElement xml)
      {
        IDictionary keyedtypes = GetKeyedTypesDictUsingReflection() // the registered factories
        foreach(var x in xml.Elements("YourClassesNode"))
        {
          string key = //get key from xml
          yield return keyedTypes[key].DeserializeFromXML(x);
        }
      }
    }
