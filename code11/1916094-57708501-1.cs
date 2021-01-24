json
[
  {
     "id" : 1
  },
  {
     "id" : 2
  },
  {
     "id" : 3
  }
]
And you can deserilize it like that:  
c#
var content = await response.Content.ReadAsStringAsync();
var list = JsonConvert.DeserializeObject<List<MyClass>>(content);
Where `orderList` is  a `List<MyClass>`  
c#
public class MyClass
{
    public int id { get; set; }
}
