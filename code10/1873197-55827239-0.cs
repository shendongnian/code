    public Button[] MPS;
    for(int i = 0; i < gm.MP.Length; i++)
    {
        int j = i;
        MPS[i].onClick.AddListener(() => MPButtonHandle(j));
    }
    void MPButtonHandle(int i)
    {
        MP = gm.MP[i];
    };
