    using System.Linq;
    ...
    Dictionary<GameObject, SomeEnum> GameObjectToValue = new Dictionary<GameObject, SomeEnum>();
    private List<SomeEnum> GetDecendingValues()
    {
        return 
            // this first query returns an IEnumerable<KeyValuePair<GameObject, SomeEnum>>
            // which is sorted descending by the distance (furthest = first element, closest = last)
            // from the THE_VECTOR_TO_COMOPARE_TO
            GameObjectToValue.OrderByDescending(kvp => Vector3.Distance(kvp.Key.transform.position, THE_VECTOR_TO_COMOPARE_TO)
            // In this second step you say you only want the values as IEnumerable<SomeEnum>
            .Select(kvp => kvp.Value)
            // And finaly you convert it again to a list (if needed)
            .ToList();
    }
