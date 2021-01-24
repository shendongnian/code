public interface IPercent
{
    float Percent { get; }
}
public class Sheet_1_VM : IPercent
{
    public float Percent { get; set; }
}
public class Sheet_2_VM : IPercent
{
    public float Percent { get; set; }
}
public class ModelOfExcel_VM : Object
{
    public List<Sheet_1_VM> Sheet1 { get; set; }
    public List<Sheet_2_VM> Sheet2 { get; set; }
}
public static class Program
{
    public static void Main()
    {
        var model = new ModelOfExcel_VM()
        {
            Sheet1 = new List<Sheet_1_VM>()
            {
                new Sheet_1_VM() { Percent = 1.0f },
                new Sheet_1_VM() { Percent = 2.0f },
            },
            Sheet2 = new List<Sheet_2_VM>()
            {
                new Sheet_2_VM() { Percent = 3.0f },
                new Sheet_2_VM() { Percent = 4.0f },
            },
        };
        
        var pageswithpercent = new List<string>() { "1", "2" }; 
        foreach (var page in pageswithpercent)
        {
            var thisPage = (IEnumerable<IPercent>)model.GetType().GetProperty("Sheet" + page).GetValue(model);
            foreach (var item in thisPage)
            {
                Console.WriteLine(item.Percent);
            }
        }
    }
}
