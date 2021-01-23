    private void listView_PreviewKeyDown(object sender, KeyEventArgs e)
    {
	    if (!e.IsRepeat && e.Key == Key.Space)
	    {
		    //Check items for selection.
		    bool notMixed = listView.SelectedItems.Cast<object>().Any(item => ((yourItemsClass)item).Selected) ^
				            listView.SelectedItems.Cast<object>().Any(item => !((yourItemsClass)item).Selected);
		    foreach (var item in listView.SelectedItems)
		    {
			    yourItemsClass t = (yourItemsClass)item;
			    t.Selected = notMixed ? !yourItemsClass.Selected : true;
		    }
	    }
    }
