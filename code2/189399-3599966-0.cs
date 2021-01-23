    public class HierarchyGenerator
    {
        private List<int> levels = new List<int> { 1 };
        public void DownOneLevel()
        {
            levels.Add(1);
        }
        public void UpLevels(int numLevels)
        {
            if (levels.Count < numLevels + 1)
                throw new InvalidOperationException(
                    "Attempt to ascend beyond the top level.");
            for (int i = 0; i < numLevels; i++)
                levels.RemoveAt(levels.Count - 1);
            MoveNext();
        }
        public void MoveNext()
        {
            levels[levels.Count - 1]++;
        }
        public string Current
        {
            get
            {
                return new string(' ', (levels.Count - 1) * 2)
                     + string.Join(".", levels.Select(l => l.ToString()));
            }
        }
    }
    static partial class Program
    {
        static void Main()
        {
            var hg = new HierarchyGenerator();
            Console.WriteLine(hg.Current);  // 1
            hg.DownOneLevel();
            Console.WriteLine(hg.Current);  // 1.1
            hg.DownOneLevel();
            Console.WriteLine(hg.Current);  // 1.1.1
            hg.MoveNext();
            Console.WriteLine(hg.Current);  // 1.1.2
            hg.MoveNext();
            Console.WriteLine(hg.Current);  // 1.1.3
            hg.UpLevels(1);
            Console.WriteLine(hg.Current);  // 1.2
            hg.MoveNext();
            Console.WriteLine(hg.Current);  // 1.3
            hg.UpLevels(1);
            Console.WriteLine(hg.Current);  // 2
            hg.DownOneLevel();
            Console.WriteLine(hg.Current);  // 2.1
        }
    }
