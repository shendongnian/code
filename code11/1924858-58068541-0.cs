    public void CreateBasicWall()
    {
         buildHandler.typeToInstall = typeof(Wall);
    }
    void Build(Tile tile, Type typeToInstall)
    {
        GameObject go = new GameObject();
        go.AddComponent(typeToInstall);
        // or even a bit shorter
        //GameObject go = new GameObject(typeToInstall);
    }
