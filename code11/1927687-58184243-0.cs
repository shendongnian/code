static IEnumerable<(T, T)> PairWise<T>(IEnumerable<T> collection)
{
    var queue = new Queue<T>();
    foreach (T item in collection)
    {
        queue.Enqueue(item);
        if (queue.Count == 2)
        {
            T x = queue.Dequeue();
            T y = queue.Peek();
            yield return (x, y);
        }
    }
}
and use it:
foreach ((int x, int y) tuple in PairWise(new[] {1, 2, 3, 4, 5}))
{
    Console.WriteLine($"{x} {y}");
}
