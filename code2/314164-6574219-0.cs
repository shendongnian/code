    public class Collect<TItem> where TItem : struct
    {
        public Collect<TItem> collectObject;
        public TItem? firstObject;
        public void Add(TItem item)
	{
            if (collectObject == null)
            {
                collectObject = new Collect<TItem>();
                firstObject = item;
            }
            else 
            {
                this.collectObject.Add(item);
            }
        }
        public void Show()
        {
            if (firstObject.HasValue)
                Console.WriteLine(firstObject.ToString());
            if (collectObject != null)
                collectObject.Show();           
        }
    }
