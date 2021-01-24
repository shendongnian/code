    public ViewModel()
    {
    	Load = new RelayCommand(obj =>
    	{
    		try
    		{
    			// Load your stuff here
    			Items = new List<string>() { "Item1", "Item2", "Item3", "Item4" };
    		}
    		catch (Exception ex)
    		{
    			MessageBox.Show(ex.Message);
    		}
    	});
    }
