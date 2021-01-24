C#
public class MyModel
{
  public SFOpportunity Opportunity { get; set; }
  private MyModel() { }
  public static async Task<MyModel> CreateAsync(string id)
  {
    var result = new MyModel();
    await result.setOpportunityAsync(id);
    return result;
  }
  private async Task setOpportunityAsync(string id)
  {
    ...
  }
}
