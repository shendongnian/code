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
           }
    }
