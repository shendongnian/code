	public class Item
	{
	    public int Value { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
	}
	public static class EnumerableExtensions
	{
		public static IEnumerable<Item> WithUpdate(this IEnumerable<Item> enumerable)
        {
            using (var enumerator = enumerable.GetEnumerator())
            {
                enumerator.MoveNext();
                Item previous, current=null;
                previous = (Item)enumerator.Current;
                while (enumerator.MoveNext())
                {
                    current = (Item)enumerator.Current;
                    if (previous.End >= current.Start)
                    {
                        previous.End = ((Item)enumerator.Current).Start.AddDays(-1);
                    }
                    yield return previous;
                    previous = (Item)enumerator.Current;
                }
                yield return current;
            }
        }
	}
	static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Item> list = new List<Item>() {
                new Item() { Value = 1, Start = DateTime.Now, End = DateTime.Now.AddDays(10) },
                new Item() { Value = 2, Start = DateTime.Now.AddDays(8), End = DateTime.Now.AddDays(15) },
                new Item() { Value = 3, Start = DateTime.Now.AddDays(12), End = DateTime.Now.AddDays(20) }
            };
            foreach (Item item in list) {
                Console.WriteLine("Star ={0},End={1}", item.Start.ToString(), item.End.ToString());
            }
            foreach (Item item in list.WithUpdate())
            {
                Console.WriteLine("Star ={0},End={1}", item.Start.ToString(), item.End.ToString());
            }
            Console.ReadLine();
            //Item item = new Item() { Value = 1, Start = DateTime.Now, End = DateTime.Now.AddDays(10) };
        }
