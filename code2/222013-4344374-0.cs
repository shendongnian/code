    public class Temp
    {
        public int Count { get; set; }
    }
    static void Main(string[] args)
    {
        var t = new Temp() {Count = 5};
        for (int i = 0; i < t.Count; i++)
        {
            Console.WriteLine(i);
            t.Count--;
        }
        Console.ReadLine();
    }
