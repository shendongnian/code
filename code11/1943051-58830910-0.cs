    using System.Linq;
    AsyncOperation[] asyncs;
    UnityWebRequest[] requests;
    IEnumerator GetTexture() 
    {
        requests = new UnityWebRequest[10];
        asyncs = new AsyncOperation[10];
        for (var i = 0; i < 10; i++)
        {
            var url = string.Format("https://galinha.webhost.com/img/{0}.jpg", words[i]);
            requests[i] = UnityWebRequestTexture.GetTexture(url);
            // starts the request but doesn't wait for it for now
            asyncs[i] = requests[i].SendWebRequest();
        }
        // Now wait for all requests parallel
        yield return new WaitUntil(AllRequestsDone);
        for(var i = 0; i < 10; i++)
        {
            if(requests[i].isNetworkError || requests[i].isHttpError) 
            {
                selectionSprites.Add(sprites[i]);
            }
            else 
            {
                Texture2D myTexture = ((DownloadHandlerTexture)requests[i].downloadHandler).texture;
                Sprite spriteFromWeb = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0, 0));
                selectionSprites.Add(spriteFromWeb);  
            }
        }
    }
    private bool AllRequestsDone()
    {
        // A little Linq magic
        // returns true if All requests are done
        return asyncs.All(r => r.isDone);
    } 
