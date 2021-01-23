    public class MyViewData
    {
      List<MyDataRecords> MyData { get; set; }
      List<MyDataRecords> News { get { return MyData.Where(m => m.Category = "News"); } }
      List<MyDataRecords> Events { get { return MyData.Where(m => m.Category = "Events"); } }
    }
