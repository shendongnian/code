    class Program
    {
        public static void Main()
        {
            var list1 = new List<Data>
            {
                new Data("63245-8",  10),
                new Data("08657-5", 100),
                new Data("29995-0", 500),
                new Data("12345-0",  42)
            };
            var list2 = new List<Data>
            {
                new Data("63245-8", 100),
                new Data("12345-0",  42),
                new Data("67455-1", 100),
                new Data("44187-10", 50),
            };
            var comparer = new DataComparer();
            var newItems     = list2.Except(list1, comparer);    // The second list without items from the first list = new items.
            var deletedItems = list1.Except(list2, comparer);    // The first list without items from the second list = deleted items.
            var keptItems    = list2.Intersect(list1, comparer); // Items in both lists = kept items (but note: Amount may have changed).
            List<ComparedData> result = new List<ComparedData>();
            result.AddRange(newItems    .Select(item => new ComparedData(item, ComparisonState.New,     0)));
            result.AddRange(deletedItems.Select(item => new ComparedData(item, ComparisonState.Deleted, 0)));
            
            // For each item in the kept list, determine if it changed by comparing it to the first list.
            // Note that the "list1.Find()` is an O(N) operation making this quite slow.
            // You could speed it up for large collections by putting list1 into a dictionary and looking items up in it -
            // but this is unlikely to be needed for smaller collections.
            result.AddRange(keptItems.Select(item =>
            {
                var previous = list1.Find(other => other.Serial == item.Serial);
                return new ComparedData(item, item.Amount == previous.Amount ? ComparisonState.Unchanged : ComparisonState.Changed, previous.Amount);
            }));
            // Print the result, for illustration.
            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
