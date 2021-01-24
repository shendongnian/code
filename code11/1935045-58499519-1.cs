    public DestroyableObject obj1;
    public DestroyableObject obj2;
    public void Check()
    {
        if (obj1.Destroyed && obj2.Destroyed)
        {
            Instantiate(prefab, obj1.Position, Quaternion.identity);
        }
    }
