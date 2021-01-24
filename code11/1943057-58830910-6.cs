    using System.Linq;
    ...
    UnityWebRequestAsyncOperation[] requests;
    IEnumerator GetTexture() 
    {
        requests = new UnityWebRequestAsyncOperation[10];
        for (var i = 0; i < 10; i++)
        {
            var url = string.Format("https://galinha.webhost.com/img/{0}.jpg", words[i]);
            var www = UnityWebRequestTexture.GetTexture(url);
            // starts the request but doesn't wait for it for now
            requests[i] = www.SendWebRequest();
        }
        // Now wait for all requests parallel
        yield return new WaitUntil(AllRequestsDone);
        // Now evaluate all results
        for(var i = 0; i < 10; i++)
        {
            var www = requests[i].webRequest;
            if(www.isNetworkError || www.isHttpError) 
            {
                selectionSprites.Add(sprites[i]);
            }
            else 
            {
                Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                Sprite spriteFromWeb = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0, 0));
                selectionSprites.Add(spriteFromWeb);  
            }
        }
        ...
    }
    private bool AllRequestsDone()
    {
        // A little Linq magic
        // returns true if All requests are done
        return requests.All(r => r.isDone);
        // Ofcourse you could do the same using a loop
        //foreach(var r in requests)
        //{
        //    if(!r.isDone) return false;
        //}
        //return true;
    } 
