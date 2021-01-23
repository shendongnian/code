    public class MyVisitor : IVisitor<TheItem>
    {
        private List<TheItem> _visitedItems = new List<TheItem>();
        public bool Visit(TheItem item)
        {
             if (_visitedItems.Contains(item)) return true;
             _visitedItems.Add(item);
             //process here. Return false when iteration should be stopped.
        }
    }
    public class MyItems : IVisitable<TheItem>
    {
         public void Accept(IVisitor<TheItem> visitor)
         {
             foreach (var item in items)
             {
                 if (!visitor.Visit(item))
                     break;
             }
         }
    }
