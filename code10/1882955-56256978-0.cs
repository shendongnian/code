public static void Main()
{
    string sntnc = "Example";
    foreach (char chrctr in sntnc)
    {
        Console.Write(chrctr);
        System.Threading.Thread.Sleep(50);
    }
    
    Console.ReadKey();
}
