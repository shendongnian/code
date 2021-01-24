    public static void DumpEntries(JObject obj, string indent = "")
    {
        JArray entries = (JArray)obj["entries"];
        if (entries != null)
        {
            foreach (JToken entry in entries)
            {
                if (entry.Type == JTokenType.String)
                {
                    debugOutput(indent + entry.ToString());
                }
                else if (entry.Type == JTokenType.Object && (string)entry["type"] == "entries")
                {
                    debugOutput(indent + "**" + (string)entry["name"] + "**");
                    DumpEntries((JObject)entry, indent + "  ");
                }
            }
        }
    }
