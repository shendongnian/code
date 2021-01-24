`
static void Main(string[] args)
{
    var test = "Raiden: HelloWorld";
    List<string> split = test.Split(':').Select(t => t.Trim()).ToList();
    Console.WriteLine(split[0].Length);
    Console.WriteLine(split[1].Length);
    Console.ReadLine();
}
`
I get:
    6
    10
