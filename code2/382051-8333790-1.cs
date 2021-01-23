    private void countryDropDownBox_SelectedIndexChanged()
    {
      string selectedCountry = countryDropDownBox.SelectedItem.Text;
      FillStateDropwDownList(selectedCountry);
      
    }
    // I must say that you don't have to use a parameter for that
    // you can basically take countryDropDownBox.SelectedItem.Text in the below method
    // but I prefer to do that in countryDropDownBox_SelectedIndexChanged because
    // selectedCountry actually belongs to countryDropDownBox
    private void FillStateDropwDownList(string selectedCountry)
    {
     stateDropDownBox.Items.Clear();
     //use selectedCountry for filtering query from database tale or something else
     //use a foreach(I'd prefe for) loop to add the items in the returning string list which contains the states for selected country by stateDropDownBox.Items.Add(item)
    }
