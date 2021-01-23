    public class Class2 : ObservableDictionary<string, string>
    {
    	public Class2()
    	{
    	}
    }
    public class Class1
    {
    	public Class1()
    	{
    		Class2 class2 = new Class2();
    		class2.CollectionChanged += new OnCollectionChanged;
    	}
    
    	void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    	{
    		if (e.Action == NotifyCollectionChangedAction.Add)
    		{
    			foreach (KeyValuePair<string, string> kvp in e.NewItems)
    			{
    				listView1.Add(kvp.Value);
    			}
    		}
    	}
    }
