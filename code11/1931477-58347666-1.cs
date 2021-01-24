void Main()
{
    using (var reader = new StreamReader("D:\\PROJECTS\\2019\\DVP_Salary_Payment_Local\\Payment\\test_2.csv"))
    using (var csv = new CsvReader(reader))
    {
        csv.Configuration.Delimiter = ",";
        var records = csv.GetRecords<ItemResource>();
    }
}
public class ItemResource
{
    public string Msisdn { get; set; }
    public float Amount { get; set; }
    public string PersonName { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }
    public int Notify { get; set; }
}
You can view a nearly identical example listed on their site [here][2].
  [1]: https://joshclose.github.io/CsvHelper/
  [2]: https://joshclose.github.io/CsvHelper/examples/reading/get-class-records/
