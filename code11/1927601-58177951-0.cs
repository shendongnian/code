string[] sum = new string[256];
for (int i = 1; i < 256; i++)
{
    int result = Convert.ToInt32(dt.Compute("Sum(BIN" + i.ToString() + ")", string.Empty));
    if (result <= 0)
    {
        dt.Columns.Remove("BIN" + i.ToString() + "");
    }
}
This can be simplified further by using the return value of the method directly in the `if` condition. We can also use interpolated strings instead of concatenation:
string[] sum = new string[256];
for (i = 1; i < sum.Length; i++)
{
    if(Convert.ToInt32(dt.Compute($"Sum(BIN{i})", string.Empty)) <= 0)
    {
        dt.Columns.Remove($"BIN{i}");
    }
}
