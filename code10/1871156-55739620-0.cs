    public IEnumerator GetTexture(string URL, Action<Sprite> callback) 
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError) 
        {
            Debug.LogError(www.error, this);
            callback?.Invoke(null);
        }
        else 
        {
            Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
           
            // E.g. for using the center of the image
            // but half of the size
            var rect = new Rect(texture.width / 4, texture.height / 4, texture.width / 2, texture.height / 2);
            // Create the sprite
            var sprite = Sprite.Create(texture, text, Vector2.one * 0.5f);
            // execute the callback
            callback?.Invoke(sprite);
        }
    }
