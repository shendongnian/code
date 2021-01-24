public override string ToString()
{
  return this.GetPropertiesAsText();
}
static public class PropertiesListerHelper
{
  static private bool ToStringMutex;
  static public string GetPropertiesAsText(this object instance)
  {
    if ( ToStringMutex )
      return $"<Reentrancy in {instance.GetType().Name}.ToString()>";
    ToStringMutex = true;
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
      ToStringMutex = false;
    }
  }
}
You can adapt the method to format the output as you want.
