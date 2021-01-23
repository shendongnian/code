    public class NewItemEventArgs<T> : System.EventArgs
    {
    	public T NewItem { get; private set; }
    	public NewItemEventArgs(T newItem)
    	{
    		this.NewItem = newItem;
    	}
    }
