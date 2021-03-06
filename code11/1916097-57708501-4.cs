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
And you can deserialize it like that:  
c#
var content = await response.Content.ReadAsStringAsync();
var list = JsonConvert.DeserializeObject<List<MyClass>>(content);
Where `list` is a `List<MyClass>`  
c#
public class MyClass
{
    public int id { get; set; }
}
