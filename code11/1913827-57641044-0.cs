    var namesToKeep = new string[] { "ID", "Code", "OrderDetails", "ItemID", "Quantity" };
    var jArray = JArray.Parse(jsonString);
    foreach (var prop in jArray.Descendants().OfType<JProperty>().ToList())
    {
        if (!namesToKeep.Contains(prop.Name))
            prop.Remove();
    }
    jsonString = jArray.ToString();
