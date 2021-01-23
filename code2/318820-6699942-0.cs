    myListView.Invoke( (Action) (() => 
        {
            myListView.Columns.Add("Column 1", -2, HorizontalAlignment.Left);
	        myListView.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
	        myListView.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
	        myListView.Columns.Add("Column 4", -2, HorizontalAlignment.Center);
        }));
