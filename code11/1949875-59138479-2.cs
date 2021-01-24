    void Start()
    { 
        List<Vector3> contList = new List<Vector3>();
        for (int i = 0; i < ammount_of_pallet; i++)
        {
            contList.Add(new Vector3(startX, 0.5f, 0f));
            startX = startX + pallet.transform.localScale.x;
        }
        Shuffle(contList);
        foreach (Vector3 position in contList)
        {
            Instantiate(spawnee, position, Quaternion.identity);
        }
        contList.Clear();
    }
    private System.Random rng = new System.Random();  
    public void Shuffle<T>(IList<T> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
