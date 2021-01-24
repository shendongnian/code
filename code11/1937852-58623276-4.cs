public override string ToString()
{
  return this.GetPropertiesAsText();
}
>PropertiesListerHelper.cs
using System.Reflection;
static public class PropertiesListerHelper
{
  static private bool IsProcessing;
  static public string GetPropertiesAsText(this object instance)
  {
    if ( IsProcessing )
      return $"<Reentrancy in {instance.GetType().Name}.ToString()>";
    IsProcessing = true;
    try
    {
      string result = "";
      var list = instance.GetType().GetProperties().OrderBy(item => item.Name);
      foreach ( var property in list )
      {
        var value = property.GetValue(instance);
        result += $"{property.Name} = {(value == null ? "<null>" : value)}, ";
      }
      return result.TrimEnd(", ".ToArray());
    }
    catch ( Exception ex )
    {
      return $"<Exception in {instance.GetType().Name}.ToString(): {ex.Message}>";
    }
    finally
    {
      IsProcessing = false;
    }
  }
}
So the behavior works even if the class design is changing.
You can adapt the method to format the output as you want.
The management of the case of reentrancy may be improved because it can cause stack overflow on forms for example.
