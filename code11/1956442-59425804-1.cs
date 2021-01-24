c#
public class AppInfo
{
  [Required(ErrorMessage = "Campo obrigatório")]
  public Plant nick { get; set; }
  [Required(ErrorMessage = "Campo obrigatório")]
  public string version { get; set; }
  public string description { get; set; }
}
public class Plant {
   private readonly string[] AllowedNames = { "Tree", "Flower" };
   public string Name { get; }
   Plant(string plant) {
      if(false == AllowedNames.Contains(plant)) {
          throw new ArgumentException($"{plant} isn't allowed.");
      }
      this.Name = plant;
   }
}
In `AppInfo`, you will access the property with `nick.Name`.
Alternatively, you can add this logic to the `AppInfo` constructor directly. Although, if you intend to use this logic in other entities, creating a custom class is better.
