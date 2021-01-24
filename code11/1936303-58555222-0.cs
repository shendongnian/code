    dynamic dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject(source);
    foreach (var layer in dynObj.layers)
    {
        if (layer["metadata"] != null)
        {
            int _numCells = (int)layer["metadata"]["cells"].ToObject<int>();
            int _numRecords = (int)layer["metadata"]["records"].ToObject<int>();
            string _queryTime = (string)layer["metadata"]["query"].ToObject<string>();
            int _sample = (int)layer["metadata"]["sample"].ToObject<int>();
            int _calibrate = (int)layer["metadata"]["calibrate"].ToObject<int>();
        }
        else if (layer["lookups"] != null)
        {
    
            string group = "User Profile";
    
            for (int i = 0; ; i++)
            {
                string col = String.Format("p_{0}", i.ToString());
                if (layer["lookups"][group][col] == null)
                    break;
                string descr = (string)layer["lookups"][group][col].ToObject<string>();
    
            }
        }
    }
