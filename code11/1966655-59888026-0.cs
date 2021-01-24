c#
private void CheckValues(int p, int a, int s)
{
    var values = new[] { p, a, s };
    if (values.Sum() == 0 || values.Count(v => v != 0) == 1)
        Console.WriteLine("Error");
    else
        Console.WriteLine("OK");
}
Or
c#
private void CheckValues(params int[] values)
{
    if (values.Sum() == 0 || values.Count(v => v != 0) == 1)
        Console.WriteLine("Error");
    else
        Console.WriteLine("OK");
}
Thus:
c#
CheckValues(0, 0, 0); // <- Error
CheckValues(0, 0, 1); // <- Error
CheckValues(0, 1, 2); // <- OK
CheckValues(1, 2, 3); // <- OK
