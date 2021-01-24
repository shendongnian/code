CSharp
public class Detail1
{
    public string CustomSalary { get; set; }
    public int Max { get; set; }
    public decimal Max2 { get; set; }
}
It could be :
CSharp
public class Detail2
{
    public string CustomSalary { get; set; }
    public string Max { get; set; }
    public string Max2 { get; set; }
}
> Please be more specific
using `Detail2` class, you can use `Parse` extension methods (numeric types has this extension method):
CSharp
if(!string.IsNullOrWhiteSpace(detail[0].CustomSalary) 
    && int.Parse(details[0].Max) <= 0 
    && decimal.Parse(details[0].Max2 <= 0.0m))
{
    //....
}
You can use `System.Convert` class too:
CSharp
if(!string.IsNullOrWhiteSpace(detail[0].CustomSalary) 
    && Convert.ToInt(details[0].Max) <= 0 
    && Convert.ToDecimal(details[0].Max2 <= 0.0m))
{
    //....
}
And if you're not sure there's any value (in `details[0]`), you can add `?` after `details[0]` and/or use `TryParse` extension method:
CSharp
int.TryParse(details[0].Max, out int max);
decimal.TryParse(details[0]?.Max2, out decimal max2);
if(!string.IsNullOrWhiteSpace(detail[0]?.CustomSalary) 
    && max <= 0
    && max2 <= 0.0m)
{
    //....
}
I this case, you don't know the type of `Max` and `Max2` properties. (it can be a simple `object`)
