csharp
public string getActions(bool isView, bool isAddupdate, bool isDelete)
{
    var codes = new List<int>();
    if (isView) codes.Add(0);
    if (isAddupdate) codes.Add(1);
    if (isDelete) codes.Add(2);
    return string.Join(",", codes);
}
