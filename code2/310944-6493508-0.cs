    DataRetriever.LoadDataFromServer( this.gridView1, this.myDataTable );
    // ... elsewhere ...
    public class DataRetriever {
        // uiSynchronizer can run delegates in UI thread
        // uiSynchronizer can be instance of "System.Windows.Forms.Control" (or derived) class
        public void LoadDataFromServer( ISynchronizeInvoke uiSynchronizer, DataTable target ) {
            // QueueUserWorkItem runs delegate in separated thread
            ThreadPool.QueueUserWorkItem((_state)=>{
                // getting rows from server
                var serverRows = server.GetAnswer(parameter);
    
                // addRows delegate must be called on UI thread
                Action addRows = ()=> {
                    try {
                        target.BeginLoadData();
                        foreach(DataRow in serverRow in serverRows) {
                            target.Rows.Add( serverRow.ItemArray );
                        }
                    }
                    finally {
                        target.EndLoadData();
                    }
                };
    
                // uiSynchronizer.Invoke runs "addRows" delegate on UI thread
                uiSynchronizer.Invoke(addRows);
            });
        }
    }
