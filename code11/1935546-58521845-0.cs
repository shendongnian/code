Dictionary<string, string> Data = new Dictionary<string, string>
{
	{ "John", "aaa" },
	{ "Tom", "bbb" },
	{ "David", "ccc" }
};
List<string> PersonList = new List<string>
{
	"Tom",
	"Peter"
};
List<string> PersonListNotInDictionary = PersonList.Where(pl => !Data.ContainsKey(pl))
                                                   .ToList();
