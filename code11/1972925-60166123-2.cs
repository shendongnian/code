    using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
    {
           yield return uwr.SendWebRequest();
    
           if (uwr.isNetworkError || uwr.isHttpError)
           {
               Debug.Log(uwr.error);
           }
           else
           {
               img =  DownloadHandlerTexture.GetContent(uwr);
               specificimage.sprite =Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
           }
    }
