    void Start()
    { 
        List<Vector3> contList = new List<Vector3>();
        for (int i = 0; i < ammount_of_pallet; i++)
        {
            contList.Add(new Vector3(startX, 0.5f, 0f));
            startX = startX + pallet.transform.localScale.x;
        }
        Random random = new Random();
        for (int i = 0; i < contList.Count; i++
        {
            var index = Random.Range(0, contList.Count);
            Vector3 position = RemoveAndGet(contList, index);
            Instantiate(spawnee, position, Quaternion.identity);
        }
    }
    public T RemoveAndGet<T>(IList<T> list, int index)
    {
        lock(list)
        {
            T value = list[index];
            list.RemoveAt(index);
            return value;
        }
    }
