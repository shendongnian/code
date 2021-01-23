static int maxNr = 10;
static int myValue = 1;
private static void Test()
{
    int lastValue = myValue;
    int choice = int.Parse(Console.ReadLine());  // only 1 or 2 accepted.
    //Only choice = 1 in displayed here.
    if (choice == 1)
    {
        while (myValue &lt;= maxNr)
        {
            Console.WriteLine(myValue);
            myValue = myValue + 3;
        }
    }
    if (lastValue == 1)
    {
        myValue = lastValue + 3 - 1;
    }
    else
    {
        myValue = lastValue - 1;
    }
}
<br><b>Method Call</b>
static void Main(string[] args)
{
    Test();
    Test();
    Test();
    Console.ReadLine();
}
