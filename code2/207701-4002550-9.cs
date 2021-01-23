    public static string Cascade(params string[] jsonArray)
    {
        JObject result = new JObject();
        foreach (string json in jsonArray)
        {
            JObject parsed = JObject.Parse(json);
            Merge(result, parsed);
        }
        return result.ToString();
    }
    private static void Merge(JObject receiver, JObject donor)
    {
        foreach (var property in donor)
        {
            JObject receiverValue = receiver[property.Key] as JObject;
            JObject donorValue = property.Value as JObject;
            if (receiverValue != null && donorValue != null)
                Merge(receiverValue, donorValue);
            else
                receiver[property.Key] = property.Value;
        }
    }
