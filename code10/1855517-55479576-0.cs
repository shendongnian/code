    public static string colors_PreviousItem;
    
    private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Save the Previous Item
        if (!string.IsNullOrEmpty(vm.Colors_SelectedItem))
        {
            colors_PreviousItem = vm.Colors_SelectedItem;
        }
    
        // Select Item
        vm.Colors_SelectedItem = SelectItem(vm.Colors_Items.Select(c => c.Name).ToList(),
                                            colors_PreviousItem
                                            );
    
        // I used to have the code I want to run in here
    }
    // Select Item Method
    //
    public static string SelectItem(List<string> itemsName,
                                    string selectedItem
                                    )
    {
        // Select Previous Item
        if (itemsName?.Contains(selectedItem) == true)
        {
            return selectedItem;
        }
        // Default to First Item
        else
        {
            return itemsName.FirstOrDefault();
        }
    }
