        void Start()
        {
            LoadPreviewImages();
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
