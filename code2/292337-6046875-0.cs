    public class ReportModel 
    {
      public int ID {get; private set;}
      public DateTime Date {get; private set;}
      public int Value {get; private set;}
 
      private ReportModel() {}
 
      public static ReportModel FromDataRow(DataRow dataRow)
      {
           return new ReportModel
           {
                ID = Convert.ToInt32(dataRow["id"]),
                Date = Convert.ToDateTime(dataRow["date"]),
                Value = Convert.ToInt32(dataRow["value"])
           };
      } 
      public static List<ReportModel> FromDataTable(DataTable dataTable)
      {
           var list = new List<ReportModel>();
 
           foreach(var row in dataTable.Rows)
           {
                list.Add(ReportModel.FromDataRow(row);
           }
 
           return list;
      }
    }
