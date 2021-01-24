public override string ToString()
{
  return this.GetPropertiesAsText();
}
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
        result += $"{property.Name}: {property.GetValue(instance)}" + Environment.NewLine;
      return result.TrimEnd(Environment.NewLine.ToArray());
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
You can adapt the method to format the output as you want.
The management of the case of reentrancy may be improved because it can cause stack overflow on forms for example.
