    string json = String.Empty;
    using (var sr = new StreamReader(@"d:\Documents\asd.json"))
    {
        json = sr.ReadToEnd();
    }
    JArray array = JArray.Parse(json);
    for (int i = 0; i < array.Count - 1; i++)
    {
        for (int j = i + 1; j < array.Count; j++)
        {
            if (array[i]["id"].ToString() == array[j]["id"].ToString())
            {
                foreach (var item in ((JObject)array[j]["content"]).Properties())
                {
                    try
                    {
                        ((JObject)array[i]["content"][item.Name]).Replace(item);
                    }
                    catch (Exception)
                    {
                        ((JObject)(array[i]["content"])).Add(item);
                    }
                }
                array.Remove(array[j]);
            }
        }
    }
    Console.WriteLine(array.ToString());
