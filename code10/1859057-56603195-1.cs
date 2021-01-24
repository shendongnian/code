using Dapper;
[...]
public class SalsaZima
{
  public int ID { get; set; }
  public string MySalsaColumn { get; set; }
  public string MyZimaColumn { get; set; }
}
[...]
// get data from database
using (IDbConnection dp = Dapper)
{
  string query = @"SELECT 
                     s.ID
                    ,s.MySalsaColumn
                    ,z.MyZimaColumn
				   FROM dbo.Salsa s 
                   LEFT JOIN dbo.Zima 
                     ON s.ZimaID = z.ID";
  return dp.Query<SalsaZima>(query).ToList();
}
