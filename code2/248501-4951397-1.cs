    class Program
    {
    private const string Sentence = "The quick brown fox jumps over the lazy dog";
    private const string Word = "jumps";
    static void Main(string[] args)
    {
        var indexTimes = new List<long>();
        var regexTimes = new List<long>();
        var timer = new Stopwatch();
        for (int i = 0; i < 1000; i++)
        {
            timer.Reset();
            timer.Start();
            Sentence.IndexOf(Word);
            timer.Stop();
            indexTimes.Add(timer.ElapsedTicks);
        }
        Console.WriteLine(indexTimes.Average());
        for (int i = 0; i < 1000; i++)
        {
            timer.Reset();
            timer.Start();
            Regex.Match(Sentence, Word);
            timer.Stop();
            regexTimes.Add(timer.ElapsedTicks);
        }
        Console.WriteLine(regexTimes.Average());
        Console.ReadLine();
    }
    }
