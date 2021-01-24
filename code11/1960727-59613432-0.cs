public class MyObject
{
  public string WebUrl {get;set;}
  public string Id {get;set;}
  public string Title {get;set;}
}
Then in the controller action itself -
public async Task<IHttpActionResult> syncData(MyObject smartNameHere)
