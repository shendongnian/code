    public class Program
    {
        private static void Main(string[] args)
        {
            var list1 = new List<Item>
            {
                new Item {Id = 1, ParentId = null},
                new Item {Id = 2, ParentId = null},
                new Item {Id = 3, ParentId = 1}
            };
            var list2 = new List<Item>
            {
                new Item {Id = 3, ParentId = 1}
            };
            var result = list2.Union(list1.Where(l1 => list2.All(l2 => l2.ParentId != l1.Id)));
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
    }
