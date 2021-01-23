    List<string>names = new List<string>();
    foreach (List<object> listresult in _result.Values)
    {
        foreach (JsonObject oneResult in listresult)
        {
                if (oneResult.ContainsKey("name"))
                {
                    names.Add(oneResult["name"].ToString());
                }
            }
        }
        break;
    }
