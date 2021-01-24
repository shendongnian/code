Dictionary<string, ITableInterface> dict = new Dictionary<string, ITableInterface>
{
  { "Table1", new Table1() as ITableInterface },
  { "Table2", new Table2() as ITableInterface }
};
foreach (var key in dict.Keys)
{
     var table = dict.GetValueOrDefault(key);
     table?.  // do something (question mark is there for null protection)
}
// if you just want a list of all your tables this is it
var listOfTables = dict.Keys.Select(_ => dict.GetValueOrDefault(_)).ToList();
