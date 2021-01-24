var value = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
and your Second json is `Dictionary<string, object>`.
var value = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
This code works with dynamic object but not `AcqFieldData`. Your constructors seems to have some issues when trying to create / add objects and inserting them to your Dictionary. When I tested your code, it throws error in `foreach (var pair in fields)` when fields is null.
I would suggest trying out classes with getter and setter and go from there. 
public class AcqFieldData
{
    public Dictionary<string, AcqFieldRef> Fields { get; set; }
    public List<string> ReadonlyControlAliases { get; set; }
}
public class AcqFieldRef
{
    public Guid? CardID { get; set; }
    public string Section { get; set; }
    public string Field { get; set; }
    public Object Value { get; set; }
}
// Use this in the main for 1st json
var jObject = JsonConvert.DeserializeObject<List<Dictionary<string, AcqFieldData>>>(json);
// Use this in the main for 2nd json
var jObject = JsonConvert.DeserializeObject<Dictionary<string, AcqFieldData>>(json);
