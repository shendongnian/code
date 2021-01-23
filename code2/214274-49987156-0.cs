    class SomeClass {
       public string WantedProperty { get; set; }
       public string UnwantedProperty { get; set; }
    }
    var objects = new List<SomeClass>();
    ...
    new JavaScriptSerializer().Serialize(
       objects
       .Select(x => new {
          x.WantedProperty
       }).ToArray()
    );
