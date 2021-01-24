    // the sprite we will transfer
    public Sprite targetSprite;
    // the prefab to spawn
    // directly use the component type here so we get rid of one GetComponent call
    public SpriteRenderer examplePRefab;
    [Command]
    public void Cmd_Spawn()
    {
        // ON SERVER
        var obj = Instantiate(examplePRefab);
        // on the server set the sprite right away
        obj.sprite = targetSprite;
        // spawn (sprite will not be set yet)
        NetworkServer.Spawn(obj.gameObject);
        // tell clients to set the sprite and pass required data
        Rpc_AfterSpawn(obj.gameObject, targetSprite.texture.EncodeToPNG(), new SpriteInfo(targetSprite));
    }
    [Serializable]
    private struct SpriteInfo
    {
        public Rect rect;
        public Vector2 pivot;
        public SpriteInfo(Sprite sprite)
        {
            rect = sprite.rect;
            pivot = sprite.pivot;
        }
    }
    [ClientRpc]
    private void Rpc_AfterSpawn(GameObject targetObject, byte[] textureData, SpriteInfo spriteInfo)
    {
        // ON CLIENTS
        // the initial width and height don't matter
        // they will be overwritten by load
        // also the texture format will automatically be RGB24 for jpg data
        // and RGBA32 for png
        var texture = new Texture2D(1, 1);
        //  load the byte[] into the texture
        texture.LoadImage(textureData);
        var newSprite = Sprite.Create(texture, spriteInfo.rect, spriteInfo.pivot);
        // finally set the sprite on all clients
        targetObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
