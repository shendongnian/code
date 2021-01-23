      public class ExampleMap : ClassMap<Example>
      {
        public ExampleMap()
        {
            Table("MyExampleTable");
            Id(a => a.Id).GeneratedBy.Identity();
        }
      }
