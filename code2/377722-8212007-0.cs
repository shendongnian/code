    [XmlRoot("foo")]
    public class FooDTO {
         [XmlAttribute("bar")]
         public int Bar {get;set;}
         public static implicit operator Foo(FooDTO value)
         {
             return value == null ? null : FooFactory.Create(value.Bar);
         }
         public static implicit operator FooDTO(Foo value)
         {
             return value == null ? null : new FooDTO { Bar = value.Bar; }
         }
    }
