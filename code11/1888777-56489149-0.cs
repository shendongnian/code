C#
public async Task  ConsultaBD()
{
   var influxDbClient = new InfluxDbClient("http://host:8086/", "***", "****", InfluxDbVersion.v_1_3);
   var query = "SELECT * FROM TFA WHERE time >= '2019-05-21' and time < '2019-05-22' ";
   var response = await influxDbClient.Client.QueryAsync(query, "dbname");
   string x = "";
   foreach(var item in response.Values)
   {
      x += item.toString(); //U could add + ", " to separate them appropriately
   }
   return(x);
}
However I don't know in which format the objects of the Values list are. So maybe you'll need item. and then a different property.
