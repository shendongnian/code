  var newset = (from rst in QBModel.ResultsTable
          group rst by GetGroupRepresentation(rst.CallerZipCode) into newGroup
          select new DataSourceRecord()
          {
            // ...
          }).ToList();
With the following implementation for `GetGroupRepresentation`:
private string GetGroupRepresentation(string zipCode)
{
    if (string.IsNullOrEmpty(zipCode) || zipCode.Length < 3)
    {
        return "<null>";
    }
    return zipCode;
}
I didn't understand why you are using the Substring-method or StartsWith-method for, so I just removed it.
Here is a full example:
static void Main(string[] args)
{
    var zipcodes = new List<string> { "1234", "4321", null, "", "654" };
    
    // LINQ Query Syntax
    var groups = from code in zipcodes
                 group code by GetGroupRepresentation(code) into formattedCode
                 select formattedCode;
    
    // I think this is easier to read in LINQ Method Syntax.
    // var groups = zipcodes.GroupBy(code => GetGroupRepresentation(code));
}
private static string GetGroupRepresentation(string zipCode)
{
    if (string.IsNullOrEmpty(zipCode) || zipCode.Length < 3)
    {
        return "<null>";
    }
    return zipCode;
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/Lg4Qd.png
