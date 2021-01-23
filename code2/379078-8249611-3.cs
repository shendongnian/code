    dynamic jobj = JsonUtils.JsonObject.GetDynamicJsonObject(JsonString);
    foreach (var item in jobj.MonthlyPerformance.Type)
    {
        Console.WriteLine(item.name);
        foreach (var category in item.Category)
        {
            Console.WriteLine("\t" + category.name);
            if (category.ConfigurationFund != null)
            {
                foreach (var fund in category.ConfigurationFund)
                {
                    Console.WriteLine("\t\t" + fund.name);
                }
            }
        }
    }
