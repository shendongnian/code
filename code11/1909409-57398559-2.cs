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
You could also do this by making `_trackedChildItemsList` a collection of `IDisposable`, and have the collections clear their own event handlers, but [a class clearing its own event handlers is pretty gruesome](https://stackoverflow.com/a/91853/424129). Shun reflection when conventional OOP can be used to do the job in a readable and maintainable way. And you'd still have to think of something for `IsDirty`. 
