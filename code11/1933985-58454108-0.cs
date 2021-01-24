    Dictionary<string, object> parsedData = data as Dictionary<string, object>;
      if (parsedData.ContainsKey("stringArr"))
                {
                    foreach (object o in parsedData["stringArr"] as object[])
                    {
                        string myString = o.ToString();
                    }
                }
