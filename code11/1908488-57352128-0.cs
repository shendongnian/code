static void Main(string[] args)
{
    {
        string str = System.Text.RegularExpressions.Regex.Unescape(args[0]);
        var bytes = str.Select(c => (byte)c).ToArray();
        Console.WriteLine(str);
        Console.WriteLine(BitConverter.ToString(bytes));
        Console.ReadKey();
    }
}
Results:-
C:\Temp>ConsoleApp.exe \xfc\xe8\x82\x00\x00
üè?
FC-E8-82-00-00
