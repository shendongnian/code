    void dataHelper_DataCalled(object sender, List<DataItem> dataItemsList)
    {
        // Deregister the event...
        (sender as Class1).DataCalled -= dataHelper_DataCalled; 
        //Do something with results
    }
