    string selectedItem = "";
    foreach (var selectedItem in impactedServicesData.SelectedItems)
    {
        if (selectedItem == "")
        {
            selectedItem = impactedServicesData.Items[i].Value;
        }
        else
        {
            selectedItem += "," + impactedServicesData.Items[i].Value;
        }
    }
