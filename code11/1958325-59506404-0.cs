var intList = new List<int> { 1, 2, 3 };
var asyncEnumerables = intList.Select(RunAsyncIterations);
var enumerableToIterate = async_enumerable_dotnet.AsyncEnumerable.Zip(s => s, asyncEnumerables.ToArray());
await foreach (int[] enumerablesConcatenation in enumerableToIterate)
{
    Console.WriteLine(enumerablesConcatenation.Sum()); //Sum returns 6
    await Task.Delay(2000);
}
static async IAsyncEnumerable<int> RunAsyncIterations(int i)
{
    while (true)
        yield return i;
}
