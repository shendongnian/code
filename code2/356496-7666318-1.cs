class Program
{
    [DllImport("TestLib.dll", <strong>CallingConvention=CallingConvention.Cdecl</strong>)]
    public static extern int Try(int v);
    static void Main(string[] args)
    {
        Console.WriteLine("Wynik: " + Try(20));
        Console.ReadLine();
    }
}
