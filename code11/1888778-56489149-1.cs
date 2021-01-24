C#
public async Task<string> ConsultaBD()
{
   var influxDbClient = new InfluxDbClient("http://host:8086/", "***", "****", InfluxDbVersion.v_1_3);
   var query = "SELECT * FROM TFA WHERE time >= '2019-05-21' and time < '2019-05-22' ";
   var response = await influxDbClient.Client.QueryAsync(query, "dbname");
   string x = "";
   foreach(var item in response.Values)
   {
      x += item.toString(); // You could add + ", " to separate them appropriately
   }
   return x;
}
Or a little simpler:
    return string.Join(",", response.Values.Select(v => v.ToString()));
However I don't know in which format the objects of the Values list are. So maybe you'll need item. and then a different property.
