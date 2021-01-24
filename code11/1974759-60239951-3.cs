    public class ViewModel
    {
      public DataTable Data { get; set; }
    
      public ViewModel()
      {
        DataTable dataTable = ...; // Populate DataTable
    
        // Filter DataTable using LINQ
        this.Data = dataTable
          .AsEnumerable()
          .Where(row => row["NRO"].ToString().StartsWith("3")
            && row["ACTIVE"].ToString().StartsWith("1"))
          .CopyToDataTable();
      }
    }
