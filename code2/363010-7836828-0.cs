    class A
    {
       public void OnButtonClick(object sender, Event arg)
       {
          DataSet dataSet = ....
    
          B je = new B();      
          js.ProcessData(dataSet);
       }
    }
    
    class B
    {
       public void ProcessData(DataSet dataSet)
       {
          foreach (DataRow dtrHDR in dataSet.Tables["Header"].Rows)
       }
    }
