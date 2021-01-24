    public class Destination
        {
            public string email { get; set; }   
            public List<PropertyDescription> properties { get; set; }
        }
    public class PropertyDescription
        {
                public string property { get; set; }
                public object value { get; set; }   
        }
    List<Source> sources = serialize “sourceJson”;
           var destination=new List<Destination>();
           foreach (var source in sources)
           {
               var dest = new Destination();
               foreach (var property in source.GetType().GetProperties())
               {
                   var propertValue = property.GetValue(source);
                   dest.properties.Add(new PropertyDescription
                   {
                       property = property.Name,
                       value = propertValue
                   });
               }
               destination.Add(dest);
            }
