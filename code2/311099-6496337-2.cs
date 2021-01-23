    public class SortableObservableCollection<T> : ObservableCollection<T>
    {        
        public event EventHandler Sorted;       
        public void ApplySort(IEnumerable<T> sortedItems)
        {
            var sortedItemsList = sortedItems.ToList();
            foreach (var item in sortedItemsList)
                Move(IndexOf(item), sortedItemsList.IndexOf(item));       
            if (Sorted != null)
                Sorted(this, EventArgs.Empty);
        }
    }
