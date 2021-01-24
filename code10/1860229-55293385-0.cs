    List<PublicHoliday> PublicHolidays = new List<PublicHoliday>();
    var rs = ((ADODB.Recordset)Variables.LISTPublicHolidays);
    OleDbDataAdapter A = new OleDbDataAdapter();
    DataTable dt = new DataTable();
    A.Fill(dt, rs);
    foreach (DataRow row in dt.Rows)
    {
        object[] array = row.ItemArray;
        var Public = new PublicHoliday()
        {
            DateKey = int.Parse(array[0].ToString()),
            FullDateAlternateKey = DateTime.Parse(array[1].ToString())
        };
        PublicHolidays.Add(Public);
    }
    rs.Close();
