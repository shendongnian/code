csharp
foreach (JObject item in node[subItemVar].ToList()) // Force ToList because we can't modify the children while it's enumerating
{
    Console.WriteLine(item["visible"]);
    if (item["visible"] != null && item["visible"].ToString() == "False")
    {
        item.Remove();
        continue; // Do no more processing on this node
    }
    ...
}
                        
