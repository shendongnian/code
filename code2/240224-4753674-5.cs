    private void OptionsWindowCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
	    OptionsWindow theDialog = new OptionsWindow();
        XmlLinkedNode xmlLinkedNode = e.Parameter as XmlLinkedNode;
        if (theDialog != null)
        {
            if (theDialog.ShowDialog() == true)
            {
                string checkedRadioButtonContent = theDialog.CheckedRadioButtonContent;
                xmlLinkedNode.Attributes["Status"].Value = "Available_" + checkedRadioButtonContent;
            }
        }
    }
