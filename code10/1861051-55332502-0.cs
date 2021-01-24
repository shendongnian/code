c#
public static void Main()
{
    string abc = "5 6 10 345 23 45";
    log = abc.Split(' ');
    int newPop = Conv(3,pop);
    Console.WriteLine(newPop);
}
static int Conv(int i, int load)
{
    if (log[i] != null)
    {
        return int.Parse(log[i]);
    }
    
    return load;
}
