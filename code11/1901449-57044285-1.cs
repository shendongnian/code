        void Start()
        {
    #if UNITY_EDITOR
            LoadPreviewImages();
    #endif
            // if nothing more comes here
            // rather remove this method entirely
            ...
        }
    
    #if UNITY_EDITOR
        // This allows you to call this method 
        // from the according components context menu in the Inspector
        [ContextMenu("LoadPreviewImages")]
        private void LoadPreviewImages()
        {
            foreach (var loadText in ItemTablezz)
            {
                var getImage = UnityEditor.AssetPreview.GetAssetPreview(loadText.texture);
                print(getImage);
                loadText.gameObjectTex = getImage;
            }
        }
    #endif
