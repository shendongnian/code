    public void BatchUpload(DataSet ds)
        {
            int numberPerBatch = 100;   //  Define the number per batch
            for (int skip = 0; skip < ds.Tables[0].Rows.Count; skip += numberPerBatch)  //  Group the batches
            {
                DataTable batchDT = new DataTable();    //  Create a new DataTable for the batch
                var batch = ds.Tables[0].Rows.Cast<System.Data.DataRow>().Skip(skip).Take(numberPerBatch);  //  LINQ to create the batch off existing set.
                foreach (var row in batch)  //  Import rows to new datatable
                {
                    batchDT.Rows.Add(row);
                }
                DataSet batchDS = new DataSet();    //  Create a new DataSet
                batchDS.Tables.Add(batchDT);    //  Add datatable to dataset
                string iResult = rsWsJobOrder.AddPlaning_Return_JsonString(batchDS, userId);    //  send the batch off
            }
        }
