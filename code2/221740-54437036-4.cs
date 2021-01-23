    [RPlotExporter, RankColumn]
    public class BenchmarkTest
    {
        public static IEnumerable<dynamic> TestDatas = Enumerable.Range(1, 10).Select((data, index) => $"item_no_{index}");
        [Benchmark]
        public static void ToArrayAndFor()
        {
            var datats = TestDatas.ToArray();
            for (int index = 0; index < datats.Length; index++)
            {
                var result = $"{datats[index]}{index}";
            }
        }
        [Benchmark]
        public static void IEnumrableAndForach()
        {
            var index = 0;
            foreach (var item in TestDatas)
            {
                index++;
                var result = $"{item}{index}";
            }
        }
        [Benchmark]
        public static void LinqSelectForach()
        {
            foreach (var item in TestDatas.Select((data, index) => new { index, data }))
            {
                var result = $"{item.data}{item.index}";
            }
        }
        [Benchmark]
        public static void LinqSelectStatementBodyToList()
        {
            TestDatas.Select((data, index) =>
            {
                var result = $"{data}{index}";
                return true;
            }).ToList();
        }
        [Benchmark]
        public static void LinqSelectStatementBodyToArray()
        {
            TestDatas.Select((data, index) =>
            {
                var result = $"{data}{index}";
                return true;
            }).ToArray();
        }
        [Benchmark]
        public static void LinqWhereStatementBodyAny()
        {
            TestDatas.Where((data, index) =>
            {
                var result = $"{data}{index}";
                return false;
            }).Any();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkTest>();
            System.Console.Read();
        }
    }
