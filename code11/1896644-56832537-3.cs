    public GameObject[] YourMethod<T>() where T : Component
    {
        List<GameObject> validTransforms = new List<GameObject>();
        T[] objs = Resources.FindObjectsOfTypeAll<T>();
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                //objs[i].gameObject.GetComponent<T>().ConfigureInteractives();
                validTransforms.Add(objs[i].gameObject);
            }
        }
        return validTransforms.ToArray();
    }
