    public static class SequenceDetector
    {
        public static IEnumerable<IEnumerable<T>> DetectSequenceWhere<T>(this IEnumerable<T> sequence, Func<T, T, bool> inSequenceSelector)
        {
            List<T> subsequence = null;
            // We can only have a sequence with 2 or more items
            T last = sequence.FirstOrDefault();
            foreach (var item in sequence.Skip(1))
            {
                if (inSequenceSelector(last, item))
                {
                    // These form part of a sequence
                    if (subsequence == null)
                    {
                        subsequence = new List<T>();
                        subsequence.Add(last);
                    }
                    subsequence.Add(item);
                }
                else if (subsequence != null)
                {
                    // We have a previous seq to return
                    yield return subsequence;
                    subsequence = null;
                }
                last = item;
            }
            if (subsequence != null)
            {
                // Return any trailing seq
                yield return subsequence;
            }
        }
    }
    public class test
    {
        public static void run()
        {
            var list = new List<int> { 21, 4, 7, 9, 12, 22, 17, 8, 2, 20, 23 };
            foreach (var subsequence in list
                .OrderBy(i => i)
                .Distinct()
                .DetectSequenceWhere((first, second) => first + 1 == second)
                .Where(seq => seq.Count() >= 3))
            {
                Console.WriteLine("Found subsequence {0}", 
                    string.Join(", ", subsequence.Select(i => i.ToString()).ToArray()));
            }
        }
    }
