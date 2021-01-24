private List<AlertTagModel> convert(DataTable dt)
{
   var convertedData = (from rw in dt.AsEnumerable()
                        select new AlertTagModel() {
                            alert_tag = Convert.ToString(rw["AlertTag"]),
                            layer_group = Convert.ToInt32(rw["Group"]),
                            line = Convert.ToInt32(rw["Line"]),
                            task = Convert.ToInt32(rw["Task"])
                            }).ToList();
   return convertedData;
}
then insert into DB with dapper
public void Insert_to_db(Object data)
{
     using (IDbConnection cnn = new SQLiteConnection(Tools.LoadConnectionString()))
     {
          cnn.Execute("insert into alert_tag (AlertTag, Layer_ID, Line_ID, Task_ID) values (@alert_tag, @layer_group, @line, @task)", data);
     }
}
Solved!
