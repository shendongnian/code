    foreach (int i in new EndlessRandomSequence().Take(5))
    {
        Console.WriteLine(i);
    }
    // ...
    public class EndlessRandomSequence : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            var rng = new Random();
            while (true) yield return rng.Next();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
