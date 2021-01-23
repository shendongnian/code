    public class Foo: IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 1;
            Console.WriteLine("we are at element 1");
            yield return 2;
            Console.WriteLine("we are at element 2");
            yield return 3;
            Console.WriteLine("we are at element 3");
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    
    class Program
    {
        static void Main()
        {
            var filtered = new Foo()
                .Select(item => item * 10)
                .Where(item => item < 20)
                .ToList();
        }
    }
