    public static void Remove<T>(
      string controlID,
      Action<T, string> remove) where T: new()
    {
        Logger.InfoFormat("Removing control {0}", controlID);
        T states = RadControlStates.GetStates<T>();
        remove(states, controlID);
        RadControlStates.SetStates<T>(states);
    }
