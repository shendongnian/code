    using (StreamReader r = new StreamReader(filepath))
    {
           string jsonstring = r.ReadToEnd();
           JObject obj = JObject.Parse(jsonstring);
           var jsonArray = JArray.Parse(obj["test"].ToString());
           
           //to get first value
           Console.WriteLine(jsonArray[0]["url"].ToString());
           //iterate all values in array
           foreach(var jToken in jsonArray)
           {
                  Console.WriteLine(jToken["url"].ToString());
           }
    }
