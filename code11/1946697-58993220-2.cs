private int[] delayParametersIndexSetup = new int[] {1, 0, 0, 1, 1, 0, 0, 1 };
private Dictionary<int, int> delayParameters = new Dictionary<int, int>()
{
    { 0, 1 },
    { 1, 500 }
};
(...)
foreach (var index in delayParametersIndexSetup)
{
    var value = this.delayParameters[index];
}
You could store the value and the name with 
private Dictionary<int, (string Name, int Delay)> delayParameters = new Dictionary<int, (string Name, int Delay)>()
{
    { 0, ("Wheel", 1) },
    { 1, ("Diag", 500) }
};
# B. Array - contiguous
If the values are contiguous, a list or an array could be OK too. 
private int[] delayParametersIndexSetup = new int[] {1, 0, 0, 1, 1, 0, 0, 1 };
private int[] delayParameters = new int[]{1,500};
(...)
foreach (var index in delayParametersIndexSetup)
{
   var value = delayParameters[index];
}
# C. Array/List + Linq
You could also store index, name, and value in an array or list.
var delayParametersIndexSetup = new int[] { 1, 0, 0, 1, 1, 0, 0, 1 };
var delayParameters = new List<(int Index, string Name, int Delay)>() {
    (0, "Wheel", 1),
    (1, "Diag", 500)
};
foreach (var index in delayParametersIndexSetup)
{
    var p = delayParameters.First(p => p.Index == index);
    Console.WriteLine($"{p.Name}:{p.Delay}");
}
Diag:500
Wheel:1
Wheel:1
Diag:500
Diag:500
Wheel:1
Wheel:1
Diag:500
