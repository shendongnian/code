    [TestClass]
    public class TestBase
    {
       protected void AddMockDataRow(DataTable dt)
       {
          DataRow dr = dt.NewRow();
          dr[0] = "Sydney"; // or you could generate some random string.
          dt.Rows.Add(dr);
       }
    }
