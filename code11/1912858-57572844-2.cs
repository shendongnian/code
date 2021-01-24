        for (int i = 0; i < dataTable.Count; i++)
        {
            var ro = dataTable[i]; //retrieve a strongly typed data row, not a base DataRow (do NOT use the .Rows property)
            partOrderListView.Add(new TestPartOrderListView
            {
                SortingTowerNumber = ro.SORTING_TOWER, //or whatever the column name is
                CustomerOrderName = ro.CUSTOMER, //column name etc
                ...
            });
        }
