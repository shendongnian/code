CSharp
public class Detail 
{
    public string CustomSalary { get; set; }
    public int Max { get; set; }
    public double Max2 { get; set; }
}
using `Parse` extension methods (numeric types has this extension method):
CSharp
if(!string.IsNullOrWhiteSpace(detail[0].CustomSalary) 
    && int.Parse(details[0].Max) <= 0 
    && double.Parse(details[0].Max2 <= 0.0m))
{
    //....
}
You can use `System.Convert` class:
CSharp
if(!string.IsNullOrWhiteSpace(detail[0].CustomSalary) 
    && Convert.ToInt(details[0].Max) <= 0 
    && Convert.ToDouble(details[0].Max2 <= 0.0m))
{
    //....
}
If you're not sure there's any value (in `details[0]` or in `max`), you can use `Nullables` (add `?`) or `TryParse` extension method:
CSharp
if(!string.IsNullOrWhiteSpace(detail[0]?.CustomSalary) 
    && int.TryParse(details[0]?.Max?, out max) <= 0 
    && double.TryParse(details[0]?.Max2? out max) <= 0.0m))
{
    //....
}
