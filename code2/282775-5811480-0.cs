    var datatable = new DataTable();
                DataRow[] advRow = datatable.Select("id=1");
                datatable.Rows.Remove(advRow[0]);
                //of course if there is nothing in your array this will get you an error..
    
                foreach (DataRow dr in advRow)
                {
                    // this is not a good way either, removing an
                    //item while iterating through the collection 
                    //can cause problems.
                }
    
                //the best way is:
                for (int i = advRow.Length - 1; i >= 0; i--)
                {
                    datatable.Rows.Remove(advRow[i]);
                }
                //then with a dataset you need to accept changes
                //(depending on your update strategy..)
                datatable.AcceptChanges();
