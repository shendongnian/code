cs
var items = selectedItem.ContainingProject.Properties.Cast<Property>()
var sb = new StringBuilder();
foreach (var item in items)
{
    sb.Append($"Name : {item.Name} ");
    try
    {
        sb.Append("Value : " + item.Value.ToString());
    }
    catch (Exception)
    {
        sb.Append("Value : NOT DEFINED (EXCEPTION)");
    }
    finally
    {
        sb.AppendLine();
    }
}
var output = sb.ToString();
###Solution###
It is a fairly short part, but here we go:
cs
var assemblyName = selectedItem.ContainingProject.Properties.Cast<Property>().FirstOrDefault(x=> x.Name == "AssemblyName").Value;
Basically I am just searching the first element which matches the name `AssemblyName` and get its value.
