    public class Person
    {
    	public event EventHandler AddedFriend;
    }
    
    public class PersonCollection : ObservableCollection<Person>
    {
    	public event EventHandler AddedFriend;
    
    	public PersonCollection() : base(new ObservableCollection<Person>())
    	{
    		base.CollectionChanged += PersonCollectionChanged;
    	}
    
    	private void PersonCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    	{
    		if (e.Action == NotifyCollectionChangedAction.Add)
    		{
    			foreach (Person person in e.NewItems)
    			{
    				person.AddedFriend += PersonAddedFriend;
    			}
    		}
    	}
    
    	private void PersonAddedFriend(object sender, EventArgs e)
    	{
    		var addedFriend = AddedFriend;
    		if (addedFriend != null)
    		{
    			addedFriend(sender, e);
    		}
    	}
    }
