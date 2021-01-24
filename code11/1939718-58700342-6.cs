    private Dictionary<GameObject, SomeEnum> GetDecendingDictionary()
    {
        return 
            // the sorting stays the same
            GameObjectToValue.OrderByDescending(kvp => Vector3.Distance(kvp.Key.transform.position, THE_VECTOR_TO_COMOPARE_TO)
            // convert the IEnumerable<KeyValuePair<GameObject, SomeEnum>>
            // back to a dictionary
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
