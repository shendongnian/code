`
using System.Data.SqlClient;
using System.Data;
...
using (var cn = new SqlConnection("YourConnectionString"))
{
    cn.Open();
    using (var cm = cn.CreateCommand())
    {
        cm.CommandType = System.Data.CommandType.Text;
        cm.CommandText =
            "INSERT INTO Phones (devicename, batterylife, price, antutu, ImageURL) " +
            "VALUES (@devicename, @batterylife, @price, @antutu, @ImageURL)";
        cm.Parameters.Add("@devicename", SqlDbType.VarChar, 50).Value = "Samsung-Galaxy-S10-5G";
        cm.Parameters.Add("@batterylife", SqlDbType.Int).Value = 0;
        cm.Parameters.Add("@price", SqlDbType.Int).Value = 0;
        cm.Parameters.Add("@antutu", SqlDbType.Int).Value = 0;
        cm.Parameters.Add("@ImageURL", SqlDbType.VarChar, -1).Value = "cdn2.gsmarena.com/vv/bigpic/samsung-galaxy-s10-5g.jpg";
        cm.ExecuteNonQuery();
    }
}
`
You must adjust the size/type of each `SqlParameter` as needed.
