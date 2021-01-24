public class Test
{
    public int id {get;set;}
    public string name {get;set;}  // it should be all lowercase as well. Case matters
}
public class Genres 
{
    public List<Test> genres {get;set;}
}
string JsontStr = GenreService.get();
var Serializer = new JavaScriptSerializer();
Genres a = (Genres)Serializer.Deserialize(JsontStr, typeof(Genres));
