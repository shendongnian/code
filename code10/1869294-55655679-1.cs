    // Get all objects at the top level (parentId is "custom") ordered by index
    var top = root.Table.item.Values
        .Where(x => x["parentId"].Value<string>() == "custom")
        .OrderBy(i => i["index"]);
    // Loop through top level items 
    foreach (JToken item in top)
    {
        Console.WriteLine("Index " + item["index"] + " Content:");
        Console.WriteLine(item.ToString());  // output item JSON - could be Row or something else 
        // Check whether the current item is a Row
        if (item["type"].Value<string>() == "Row")
        {
            // If so, get all items which have this row as a parent ordered by index
            var children = root.Table.item.Values
                .Where(x => x["parentId"].Value<string>() == item["id"].Value<string>())
                .OrderBy(i => i["index"]);
            // loop through the child items
            foreach (JToken child in children)
            {
                Console.WriteLine(child.ToString());  // output child JSON
            }
        }
        Console.WriteLine();
    }
