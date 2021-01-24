    Sprite[] Icons;
    Texture2D LoadedTextures;
    private void Start()
    {
        LoadedTextures = (Texture2D[])Resources.LoadAll("mat", typeof(Texture2D));
        Icons = new Sprite[loadedIcons.Length];
        for (int x = 0; x < loadedIcons.Length; x++)
        { 
            Icons[x] = Sprite.Create(
                LoadedTextures[x], 
                new Rect(0.0f, 0.0f, LoadedTextures[x].width, LoadedTextures[x].height), 
                new Vector2(0.5f, 0.5f), 
                100.0f);
        }
         GameObject sp = new GameObject();
         // Note that here you created a new empty GameObject
         // so it obviously won't have any component of type SpriteRenderer
         // so add it instead of GetComponent
         sp.AddComponent<SpriteRenderer>().sprite = Icons[0];
    }
    
