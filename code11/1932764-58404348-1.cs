static int M1(List<int> l1, List<int> l2)
    {
        List<int> g = new List<int>();
        g.AddRange(l1);
        g.AddRange(l2);
        var x = g.GroupBy(a => a)
                    .Select(root => root.FirstOrDefault())
                    .ToList();
        return x.Count();
    }
    static int M2(List<int> l1, List<int> l2)
    {
        var x = l1
           .Union(l2)
           .Select(rootId => rootId).ToList();
        return x.Count();
    }
    static int M3(List<int> l1, List<int> l2)
    {
        var g = new HashSet<int>(l1);
        g.UnionWith(l2);
        return g.Count();
    }
## Results
100.00
0.057       0.038       0.017           res: 200,200,200
0.040       0.015       0.011           res: 200,200,200
0.055       0.023       0.009           res: 200,200,200
0.062       0.036       0.022           res: 200,200,200
0.055       0.023       0.027           res: 200,200,200
1,000,000.00
1788.493    513.422     292.815         res: 1999068,1999068,1999068
1795.416    591.142     453.076         res: 1999068,1999068,1999068
2540.099    529.801     303.729         res: 1999068,1999068,1999068
1797.251    527.849     428.672         res: 1999068,1999068,1999068
2008.561    527.680     501.997         res: 1999068,1999068,1999068
10,000,000.00
34458.838   6764.472    3679.255        res: 19906255,19906255,19906255
32756.011   8507.293    3875.931        res: 19906255,19906255,19906255
## Test code 
public class Program
{
    static Random r = new Random(1);
    public static async Task Main(string[] args)
    {
        Try(100);
        Try(1000000);
        Try(10000000);
        Console.ReadLine();
    }
    public static void Try(int i)
    {
        var l1 = Enumerable.Range(0, i).Select(i => r.Next(0, int.MaxValue)).ToList();
        var l2 = Enumerable.Range(0, i).Select(i => r.Next(0, int.MaxValue)).ToList();
        NapkinQualityCompareMeasureIt(i, 5, fs: new List<Func<int>> { () => M1(l1, l2), () => M2(l1, l2), () => M3(l1, l2) });
    }
    public static void NapkinQualityCompareMeasureIt<T>(int count, int howManyTimes, List<Func<T>> fs)
    {
        //This is good only for detecting significant differences
        Console.WriteLine(count.ToString("N"));
        for (int i = 0; i < howManyTimes; i++)
        {
            var metrics = fs.Select(f =>
            {
                var sw = Stopwatch.StartNew();
                var r = f();
                return (Elapsed: sw.Elapsed, Result: r);
            });
            var res = string.Join(",", metrics.Select(m=>m.Result));
            var times = string.Join("", metrics.Select(m => $"{m.Elapsed.TotalMilliseconds.ToString("F3").PadRight(12)}"));
            Console.WriteLine($"{times}\tres: {res}");
        }
    }
}
