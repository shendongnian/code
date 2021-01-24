    using System.Linq;
    ...
    Dictionary<GameObject, SomeEnum> GameObjectToValue = new Dictionary<GameObject, SomeEnum>();
    private List<SomeEnum> GetSortetValues()
    {
        return GameObjectToValue.OrderByDescending(kvp => Vector3.Distance(kvp.Key.transform.position, THE_VECTOR_TO_COMOPARE_TO)
            .Select(kvp => kvp.Value).ToList();
    }
