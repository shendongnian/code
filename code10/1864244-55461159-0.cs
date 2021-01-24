    for (int i = tab1table.Rows.Count - 1; i >= 0; i--)
    {
        DataRow dr = tab1table.Rows[i];
    	if (!dr.ItemArray.Any(x=>(x as string).Contains(search1Text)))
        {
            dr.Delete();
        }
    	percentprogress++;
        worker.ReportProgress(percentprogress);
    }
    tab1table.AcceptChanges();
