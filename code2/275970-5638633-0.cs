    public abstract class Parameter {
      public static Parameter FromXml(XElement xElement) {
        ...
      }
      public string Name { get; set; }
      public abstract XElement ToXml();
    }
    public class Parameter<T>: Parameter {
      public T Value { get; set; }
      public override XElement ToXml() {
        ...
      }
    }
