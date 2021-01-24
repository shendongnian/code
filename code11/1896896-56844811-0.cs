    List<string> values = new List<string>(); // build list outside of the loop so that we collect all of the values
    foreach (JObject item in entry.Children<JObject>())
    {
        foreach (JProperty prop in item.Properties())
        {
            if (prop.Name.Equals("value"))
            {
                values.Add((string)prop.Value);
            }
        }
    }
    for (int i = 0; i < values.Count; i++)
    {
        sum += decimal.Parse(values[i]); // calculate the total
    }
    average = sum / values.Count; // calculate the average
