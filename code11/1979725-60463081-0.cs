    public ObservableCollection<Dashboard> DetailsList { get; set; } = new ObservableCollection<Dashboard>();
        //API Call
        details = await _clientAPI.getDashboardDetails(id);
        if (details != null)
        {
            DetailsList.Clear();
            foreach (var item in details)
            {
                DetailsList.Add(item);
            }
        }
    	
    	YourGridView.ItemSource =DetailsList;
