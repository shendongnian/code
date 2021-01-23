    public void DeleteOldById(DataTable table, int id)
    {
                       var rows = table.Rows.Cast<DataRow>().Where(x => (int)x["ID"] == id);
                       DateTime specifyDate = rows.Max(x => (DateTime)x["Date"])
                       rows.Where(x =>(DateTime)x["Date"] < specifyDate).
                            ToList().
                            ForEach(x => x.Delete());
    }
    
    public void DeleteAllOldRows(DataTable table)
    {
         var ids = table.Rows.Cast<DataRow>().Select(x => (int)x["ID"]).Distinct();
         foreach(int id in ids)
            DeleteOldById(table,id);
    }
    
