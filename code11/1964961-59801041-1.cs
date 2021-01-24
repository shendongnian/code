public class RespmobilTicket
{
  public ChilhderenTokens chilhderenTokens { get; set; }
}
public class ChilhderenTokens 
{
  public List<ChilhderenTokens> chilhderenTokens { get; set; }
  
  public string ItemId { get; set; }
  // Some properties here
}
2. [Deserialize an Object by using Newtonsoft][1] 
`
var deserializedModel = JsonConvert.DeserializeObject<RespmobilTicket>(json);
var result = deserializedModel.ChilhderenTokens[0].ChildrenTokens[0];
`
  [1]: https://www.newtonsoft.com/json/help/html/DeserializeObject.htm
