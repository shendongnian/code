csharp
using System;
using MongoDB.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
public class Models : Entity
{
    public string ModelType { get; set; }
    public Many<ModelList> ModlList { get; set; }
    public Models() => this.InitOneToMany(() => ModlList);
}
public class ModelList : Entity
{
    public string ModelHashKey { get; set; }
    public string ModelName { get; set; }
    public string ModelAttribute { get; set; }
    public One<Models> Parent { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        new DB("test");
        var parent = new Models { ModelType = "Player" };
        parent.Save();
        var ml1 = new ModelList
        {
            ModelAttribute = "Male",
            ModelName = "i am one",
            ModelHashKey = "secret",
            Parent = parent.ToReference()
        };
        ml1.Save();
        var ml2 = new ModelList
        {
            ModelAttribute = "Female",
            ModelName = "i am two",
            ModelHashKey = "secret",
            Parent = parent.ToReference()
        };
        ml2.Save();
        parent.ModlList.Add(ml1);
        parent.ModlList.Add(ml2);
        var result = (from m in DB.Collection<Models>()
                      where m.ModelType == "Player"
                      join l in DB.Collection<ModelList>() on m.ID equals l.Parent.ID into lists
                      from ml in lists
                      select ml).Where(l => l.ModelAttribute == "Male");
        var modellists = result.ToArray();
        Console.Write(modellists.First().ModelName);
        Console.ReadKey();
    }
}
resulting mongodb aggregate:
aggregate([{ 
"$match" : 
	{ "ModelType" : "Player" } }, 
	{ "$lookup" : {"from" : "ModelLists", 
				   "localField" : "_id", 
				   "foreignField" : "Parent.ID", "as" : "lists" } }, 
					{ "$unwind" : "$lists" }, 
					{ "$project" : { "lists" : "$lists", "_id" : 0 } }, 
					{ "$match" : { "lists.ModelAttribute" : "Male" } }])
