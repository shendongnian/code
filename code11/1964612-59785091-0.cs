var deserializedObject = JsonConvert.DeserializeObject<Model>(jsonResult.accountsData.journalItemAccounts);
public class Model
{
    public AnotherModel item1 { get; set; }
}
public class AnotherModel
{
    public string incomeAccount { get; set; }
    public string expenseAccount { get; set; }
    public string assetAccount { get; set; }
}
