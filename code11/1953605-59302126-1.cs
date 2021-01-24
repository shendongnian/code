    string selectedItem = "";
    foreach (var s in impactedServicesData.SelectedItems)
    {
        if (selectedItem == "")
        {
            selectedItem = s.Value;
        }
        else
        {
            selectedItem += "," + s.Value;
        }
    }
