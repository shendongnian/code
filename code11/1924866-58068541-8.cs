    public void CreateBasicWall()
    {
         buildHandler.typeToInstall = typeof(Wall);
    }
    void Build(Tile tile, Type typeToInstall)
    {
        if(typeToInstall == null)
        {
            Debug.LogError("No se va a construir nada");
            return;
        }
        GameObject go = new GameObject().AddComponent(typeToInstall);
        // or even a bit shorter
        //new GameObject("New GameObject", typeToInstall);
    }
