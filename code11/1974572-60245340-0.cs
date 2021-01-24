 C#
using (ODBC.connect = new OdbcConnection(ODBC.connectionString))
{
    double Latitude = 0.0;
    double Longitude = 0.0;
    OdbcCommand command = new OdbcCommand("SELECT Latitude, Longitude FROM TrackVehicles WHERE Registration = ?", ODBC.connect);
    command.Parameters.AddWithValue("?1", textBox1.Text);
    try
    {
        ODBC.connect.Open();
        OdbcDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Latitude = reader[0];
            Longitude = reader[1];
        }
        reader.Close()
        gMap.Position = new GMap.NET.PointLatLng(Latitude, Longitude);
    }
    catch (OdbcException exception)
    {
        MessageBox.Show(exception.Message);
    }
}
