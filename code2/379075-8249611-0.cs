    dynamic jobj = JsonUtils.JsonObject.GetDynamicJsonObject(YourJsonString);
    foreach (var item in jobj.MonthlyPerformance.Type)
    {
        Console.WriteLine(item.name);
        foreach (var subitem in item.Category)
        {
            Console.WriteLine("\t" + subitem.name);
        }
    }
