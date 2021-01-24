    foreach (String property in requiredProperties)
    {
        if (results.Properties.Contains(property))
        {
            foreach (Object myCollection in results.Properties[property])
            {
                data.Add(myCollection.ToString());
            }
        }
        else
        {
            data.Add("N/A");
        }
    }
