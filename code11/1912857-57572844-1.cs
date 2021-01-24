        for (int i = 0; i < dataTable.Count; i++)
        {
            var ro = dataTable[i]; 
            if(!ro.UserChoseThisRowBoolean) //if the user didn't tick this row
              continue; //skip on
            partOrderListView.Add(new TestPartOrderListView
            {
                SortingTowerNumber = ro.SORTING_TOWER,
                CustomerOrderName = ro.CUSTOMER,
                ...
            });
        }
