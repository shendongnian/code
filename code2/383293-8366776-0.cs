    public class GroupItems<T> : Collection<GroupItem<T>>
    {
        protected override void InsertItem(int index, T item)
        {
             // your custom code here
             // ...
             // and the actual insertion
             base.InsertItem(index, item);
        }
    }
