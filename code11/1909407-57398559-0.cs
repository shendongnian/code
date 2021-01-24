C#
public interface IObservableItemCollection
{
    event EventHandler<ItemPropertyChangedEventArgs> ItemPropertyChanged;
    event EventHandler<IsDirtyChangedEventArgs> ItemIsDirtyChanged;
    bool IsDirty { get; }
}
public interface IDirtyable
{
    //  I'm pretty sure you'll want this event here, and I think you'll want your collection to 
    //  implement IDirtyable too.
    //event EventHandler<IsDirtyChangedEventArgs> IsDirtyChanged;
    bool IsDirty { get; }
}
public class ObservableItemCollection<T>
    : ObservableCollection<T>, IObservableItemCollection
    where T : IDirtyable
{
    public bool IsDirty => this.Any(item => item.IsDirty);
    public event EventHandler<ItemPropertyChangedEventArgs> ItemPropertyChanged;
    public event EventHandler<IsDirtyChangedEventArgs> ItemIsDirtyChanged;
}
public class ViewModelBase : IDisposable, IDirtyable
{
    public virtual bool IsDirty => true;
    public virtual void Dispose()
    {
    }
}
public class ItemBase : ViewModelBase
{
    private List<IObservableItemCollection> _trackedChildItemsList = new List<IObservableItemCollection>();
    public override bool IsDirty
    {
        get
        {
            return base.IsDirty || _trackedChildItemsList.Any(coll => coll.IsDirty);
        }
    }
    protected void RegisterItemCollection<T>(ObservableItemCollection<T> collection)
                where T : ItemBase
    {
        _trackedChildItemsList.Add(collection);
        collection.ItemPropertyChanged += Collection_ItemPropertyChanged;
        collection.ItemIsDirtyChanged += Collection_ItemIsDirtyChanged;
    }
    public override void Dispose()
    {
        foreach (IObservableItemCollection collection in _trackedChildItemsList)
        {
            collection.ItemPropertyChanged -= Collection_ItemPropertyChanged;
            collection.ItemIsDirtyChanged -= Collection_ItemIsDirtyChanged;
        }
        base.Dispose();
    }
    private void Collection_ItemIsDirtyChanged(object sender, IsDirtyChangedEventArgs e)
    {
    }
    private void Collection_ItemPropertyChanged(object sender, ItemPropertyChangedEventArgs e)
    {
    }
}
public class ItemPropertyChangedEventArgs : EventArgs
{
}
public class IsDirtyChangedEventArgs : EventArgs
{
}
