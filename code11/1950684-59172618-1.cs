    private void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
    	var param = (ValueViewModel)e.Item;
    	if (((SourceViewModel)BindingContext).SelectValueCommand.CanExecute(param))
    	{
    		((SourceViewModel)BindingContext).SelectValueCommand.Execute(param);
    	}
    }
