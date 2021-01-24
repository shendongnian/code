    private List<GameObject> AddDescendantsWithTag(Transform parent)
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Transform child in parent)
        {
            list.Add(child.gameObject);
            list.AddRange(AddDescendantsWithTag(child));
        }
        return list;
    }
