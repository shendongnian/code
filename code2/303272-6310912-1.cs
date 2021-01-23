    public static void Remove<TValue>(string controlID)
    {
        Logger.InfoFormat("Removing control {0}", controlID);
        SerializableDictionary<string,TValue> states =
            RadControlStates.GetStates<SerializableDictionary<string,TValue>>();
        states.Remove(controlID);
        RadControlStates.SetStates<SerializableDictionary<string,TValue>>(states);
    }
