    public GameObject[] Prefab;
    public GameObject[] CopyPrefab;
    CopyPrefab = new GameObject[Prefab.Length];
    for (int i = 0; i < Prefab.Length; i++)
    {
        CopyPrefab[i] = Instantiate(Prefab[i]) as GameObject;
    }
