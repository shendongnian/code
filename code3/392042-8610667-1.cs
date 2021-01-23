    public MyObjectModel CreateNewRecord(MyObjectModel TheNewObject)
    {
      using (MyDataContext TheDC = new MyDataContext())
      {
        TheDC.MyTable.InsertOnSubmit(TheNewObject);
        TheDC.SubmitChanges();
      }
    
      return TheNewObject;
    }
