cs
public static int CalculateDaysLeftInMonth()
{
    int days = 0;
    List<DateTime> dates = new List<DateTime>();
    try
    {
        if (dbConnection.State != ConnectionState.Open)
            dbConnection.Open();
       OleDbCommand dbCommand = new OleDbCommand {
           CommandText = String.Format("SELECT * FROM {0} WHERE (DATEPART('yyyy', FechaFestivo) = @Year " +
                                       "AND DATEPART ('m', FechaFestivo) = @Month)", TablaCalendario)
       }
       dbCommandQuery.Parameters.AddWithValue("@Year", DateTime.Now.Year);
       dbCommandQuery.Parameters.AddWithValue("@Month", DateTime.Now.Month);
        OleDbDataReader dbReader = dbCommandQuery.ExecuteReader();
        if (!dbReader.HasRows)
            return -1;
        while (dbReader.Read())
        {
            dates.Add(new FechaFestivo(dbReader.GetDateTime(0).Date));
        }
        dbConnection.Close();
        DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                 endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                           DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (!dates.Any(ff => ff.Date == date.Date))
            {
                days++;
            }
        }
    }
    catch (OleDbException ex)
    {
        dbConnection.Close();
        return -1;
    }
    return days;
}
Using the DatePart function as said @Holger and @June7 in the comments. Thank you!
