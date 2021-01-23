    public class SpecialItemTable : DataTable
    {
    
       protected override void OnRowChanged(DataRowChangeEventArgs e)
       {
          if (e.Action == DataRowAction.Add)
          {
             r.Row["CreatedDate"] = DateTime.Now;
          }
          else if (e.Action == DataRowAction.Change)
          {
             var time = DateTime.Now;
             // Check to prevent the cascaded row change events
             if ((time - (DateTime)e.Row["LastUpdated"]).TotalMilliseconds > 2)
             {
                e.Row["LastUpdated"] = time;
             }
          }
       }
    }
