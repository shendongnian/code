cs
public static int SumUpFileContent(string file)
{
    int sum = 0;
    var lines = File.ReadAllLines(file);
    foreach (var line in lines)
    {
        if (int.TryParse(line, out int i))
            sum += i;
    }
    return sum;
}
Keep in mind : 
 - This doesn't work with numbers that have decimals, only integers. replace `int.TryParse()` with `double.TryParse()` if you have to.
 - The data must come in a very specific format (i.e. every entry must be on its own line)
