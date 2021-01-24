var incident = new IncidentImageModel();
PropertyInfo[] properties = incident.GetType().GetProperties();
for (int i = 0; i < properties.Length; i++)
{
    var pName = properties[i].Name;
    var pValue = properties[i].GetValue(incident);
    Console.WriteLine($"{pName} = {pValue}");
}
