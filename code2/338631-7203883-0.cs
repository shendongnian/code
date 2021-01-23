    public void Fill_WF_Doc(string ID, int doc)
    {
      DataClasses1DataContext DB = new DataClasses1DataContext();
      Waiting_Task entry = (from D in DB.Waiting_Tasks
                            where (D.WF_ID == ID)
                            select D).FirstOrDefault();
      entry.Doc_ID = doc;
      
      DB.SubmitChanges();
    }
