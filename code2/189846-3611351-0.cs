    class Program {
      static void Main(string[] args) {
        var d = new Defect() { Category = "bug", Status = "open" };
        var m = new DefectViewModel();
        m.CopyPropertiesFrom(d);
        Console.WriteLine("{0}, {1}", m.Category, m.Status);
      }
    }
    // compositions
    class Defect : MPropertyGettable {
      public string Category { get; set; }
      public string Status { get; set; }
      // ...
    }
    class DefectViewModel : MPropertySettable {
      public string Category { get; set; }
      public string Status { get; set; }
      // ...
    }
    // quasi-mixins
    public interface MPropertyEnumerable { }
    public static class PropertyEnumerable {
      public static IEnumerable<string> GetProperties(this MPropertyEnumerable self) {
        return self.GetType().GetProperties().Select(property => property.Name);
      }
    }
    public interface MPropertyGettable : MPropertyEnumerable { }
    public static class PropertyGettable {
      public static object GetValue(this MPropertyGettable self, string name) {
        return self.GetType().GetProperty(name).GetValue(self, null);
      }
    }
    public interface MPropertySettable : MPropertyEnumerable { }
    public static class PropertySettable {
      public static void SetValue<T>(this MPropertySettable self, string name, T value) {
        self.GetType().GetProperty(name).SetValue(self, value, null);
      }
      public static void CopyPropertiesFrom(this MPropertySettable self, MPropertyGettable other) {
        self.GetProperties().Intersect(other.GetProperties()).ToList().ForEach(
          property => self.SetValue(property, other.GetValue(property)));
      }
    }
