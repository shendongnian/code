// Order by shape first; the everybody gets it part
var shapeSorted = lst
    .OrderBy(bw => bw.shape != preShape)
    .ThenByDescending(bw => bw.shape);
// Order gropus by ascending, but if equal to last item in the previous group then first
var currentSpecialQ = preQuantity;
var r = new List<BW>();
foreach(var group in shapeSorted.GroupBy(bw => bw.shape) ) {
  r.AddRange(group.OrderBy(bw => bw.quantity != currentSpecialQ).ThenBy(bw => bw.quantity));
  currentSpecialQ = r.Last().quantity;
}
# Test
## Output
MN22, 20
MN22, 14
MN11, 10
MN11, 20
ANT, 20
ANT, 10
ANT, 16
ANT, 18
## Code
public class BW
{
    public string shape { get; set; }
    public int quantity { get; set; }
}
class Program
{
    public static void Main(string[] args)
    {
        List<BW> lst = new List<BW>(){
            new BW(){ shape = "MN11", quantity = 20},
            new BW(){ shape = "MN11", quantity = 10},
            new BW(){ shape = "MN22", quantity = 14},
            new BW(){ shape = "MN22", quantity = 20},
            new BW(){ shape = "ANT", quantity = 16},
            new BW(){ shape = "ANT", quantity = 18},
            new BW(){ shape = "ANT", quantity = 20},
            new BW(){ shape = "ANT", quantity = 10}
        };
        string preShape = "MN22";
        int preQuantity = 20;
        // Order by shape first; the everybody gets it part
        var shapeSorted = lst
            .OrderBy(bw => bw.shape != preShape)
            .ThenByDescending(bw => bw.shape);
        // Order gropus by ascending, but if equal to last item in the previous group then first
        var currentSpecialQ = preQuantity;
        var r = new List<BW>();
        foreach(var group in shapeSorted.GroupBy(bw => bw.shape) ) {
          r.AddRange(group.OrderBy(bw => bw.quantity != currentSpecialQ).ThenBy(bw => bw.quantity));
          currentSpecialQ = r.Last().quantity;
        }
        foreach(var bw in r ) Console.WriteLine($"{bw.shape}, {bw.quantity}");
        
    }
}
