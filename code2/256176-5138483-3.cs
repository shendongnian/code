    private void listBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
	    if (!e.IsRepeat && e.Key == Key.Space)
	    {
		    bool notMixed = listBox.SelectedItems.Cast<object>().Any(item => ((yourItemsClass)item).Selected) ^
				            listBox.SelectedItems.Cast<object>().Any(item => !((yourItemsClass)item).Selected);
		    foreach (var item in listBox.SelectedItems)
		    {
			    yourItemsClass t = (yourItemsClass)item;
			    t.Selected = notMixed ? !yourItemsClass.Selected : true;
		    }
	    }
    }
