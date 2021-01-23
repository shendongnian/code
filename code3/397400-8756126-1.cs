    using System.Linq;
    
    namespace ExperimentConsoleApp
    {
        class Program
        {
            static void Main()
            {
                // Check if the item is in existingItems but not in newItems
                var itemsToBeRemoved = (from e in existingItems
                                        where !newItemsLarger.Any(n => n.CellId == e.CellId)
                                        select e).ToList();
    
                // Check if the item is in newItems but not in existingItems 
                var itemsToBeAdded = (from n in newItemsLarger
                                      where !existingItems.Any(e => n.CellId == e.CellId)
                                      select n).ToList();
    
                // Match the items on Id and check if their contents equals
                var itemsToBeUpdated = (from e in existingItems
                                        from n in newItemsLarger
                                        where e.CellId == n.CellId && e.Content != n.Content
                                        select n).ToList();
            }
    
            static RetryItem[] existingItems = new[] 
                            { 
                                new RetryItem { CellId = 1, Content = "Bob" }, 
                                new RetryItem { CellId = 2, Content = "Bill" }, 
                                new RetryItem { CellId = 3, Content = "Frank" }, 
                                new RetryItem { CellId = 4, Content = "Tom" }, 
                                new RetryItem { CellId = 5, Content = "Dick" }, 
                                new RetryItem { CellId = 6, Content = "Harry" }, 
                            };
    
            static RetryItem[] newItemsLarger = new[] 
                            { 
                                new RetryItem { CellId = 1, Content = "Bob" }, 
                                new RetryItem { CellId = 3, Content = "Frank" }, 
                                new RetryItem { CellId = 4, Content = "Tom now Thoams" }, 
                                new RetryItem { CellId = 5, Content = "Dick now Dicky" }, 
                                new RetryItem { CellId = 6, Content = "Harry Now Harriet" }, 
                                new RetryItem { CellId = 7, Content = "Mary" }, 
                                new RetryItem { CellId = 8, Content = "Mungo" }, 
                                new RetryItem { CellId = 9, Content = "Midge" }, 
                            };
        }
    
        public class RetryItem
        {
            public int CellId { get; set; }
            public string Content { get; set; }
        }
    }
