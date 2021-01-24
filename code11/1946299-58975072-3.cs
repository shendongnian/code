    private void OnMySelectionChanged()
    {
    	ComboBoxItem c = (ComboBoxItem)myComboBox.SelectedItem;
    	MyGender myGender = (MyGender)c.Tag;
    	if(myGender.FemaleOrMale == 'F')
    	{
    		//Here Female
    	}
    	else
    	{
    		//Here Male
    	}
    }
