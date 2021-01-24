    public class GetTestData : IEnumerable<Int32>
    {
     public IEnumerator<Int32> GetEnumerator()
     {
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
       IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
     }
    }
