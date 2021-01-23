    public class SomeDataClass
    {
    	public event EventHandler SomeDataChanged;
    
    	private string _someData;
    	public string SomeData
    	{
    		get { return _someData; }
    		set
    		{
    			if (value != _someData) {
    				_someData = value;
    				OnSomeDataChanged();
    			}
    		}
    	}
    
    	private void OnSomeDataChanged()
    	{
    		EventHandler eh = SomeDataChanged;
    		if (eh != null) {
    			SomeDataChanged(this, EventArgs.Empty);
    		}
    	}
    }
    
    class InterestedClass
    {
    	public void Work()
    	{
    		var someData = new SomeDataClass();
    		someData.SomeDataChanged += new EventHandler(someData_SomeDataChanged);
    		someData.SomeData = "New Value";
    	}
    
    	void someData_SomeDataChanged(object sender, EventArgs e)
    	{
    		Console.WriteLine("Some data changed: {0}", ((SomeDataClass)sender).SomeData);
    	}
    }
