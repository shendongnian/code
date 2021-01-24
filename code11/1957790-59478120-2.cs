    private static DataTable GetTable(string table, DateTime startDate, DateTime endDate)
    {
        string constr = ConfigurationManager.ConnectionStrings["db_Demo"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM {table} WHERE RefDate BETWEEN @startDate AND @endDate ORDER BY ID"))
            {
                var startDateParameter = new SqlParameter("@startDate", SqlDbType.DateTime);
                startDateParameter.Value = startDate;
                var endDateParemeter = new SqlParameter("@endDate", SqlDbType.DateTime);
                endDateParemeter.Value = endDate;
                cmd.Parameters.Add(startDateParameter);
                cmd.Parameters.Add(endDateParemeter );
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
    private static DataSet GetDataSetExportToExcel(DateTime startDate, DateTime endDate)
    {
        var dtTable1 = GetTable("Table1", startDate, endDate);
        var dtTable2 = GetTable("Table2", startDate, endDate);
        var ds = new DataSet();
        ds.Tables.Add(dtTable1);
        ds.Tables.Add(dtTable2);
        return ds;
    }
    [HttpGet]
    public ActionResult Export()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Export(DateTime startDate, DateTime endDate)
    {
            DataSet ds = GetDataSetExportToExcel(startDate, endDate);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= TablesData.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            return View();
     }
