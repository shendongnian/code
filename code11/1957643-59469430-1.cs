    public class MakeModelColor()
    {
      public string Make {get; set;}
      public string Model {get; set;}
      public string Color {get; set;}
      public override string ToString()
      {
         return $"{this.Make} {this.Model} {this.Color}";
      }
    }
