    private void Sprite_Completed(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite result = handle.Result;
            // Sprite ready for use
        }
    }
    
    void Start()
    {
        AsyncOperationHandle<Sprite> SpriteHandle = Addressables.LoadAsset<Sprite>("CardSprite_Justice");
        SpriteHandle.Completed += Sprite_Completed;
    }
