public class AreaColors
{
  public Color LeftColor {get;set;}
  public Color MiddleColor {get;set;}
  public Color RightColor {get;set;}
  public IReadOnlyCollection<string> TotalColors => new[]{LeftColor, MiddleColor, RightColor}
}
I'd argue that coming up with a `Color` from a hex value should be done prior to setting it on an object like this: the writer of the consuming code should be forced to think about things like what they should do if the given string is not a valid color.
