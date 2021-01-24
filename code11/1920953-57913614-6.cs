    // A thread save queue
    ConcurrentQueue<SearchInfo> callbacks = new ConcurrentQueue<SearchInfo>();
    public IEnumerator GetMovies(string q)
    {
        var uri = "http://www.omdbapi.com/?apikey=__&s=" + q;
        using (var r = UnityWebRequest.Get(uri))
        {
            yield return r.SendWebRequest();
            if (r.isHttpError || r.isNetworkError)
            {
                Debug.Log(r.error);
            }
            else
            {
                // start the deserialization task in a background thread
                // and pass in the returned string
                Thread thread = new Thread(new ParameterizedThreadStart(DeserializeAsync));
                thread.Start(r.downloadHandler.text);
                // wait until the thread writes a result to the queue
                yield return new WaitUntil(()=> !callbacks.IsEmpty);
                // read the first entry in the queue and remove it at the same time
                if (callbacks.TryDequeue(out var result))
                {
                    GetComponent<EventManager>().onSearchInfoGet(result);
                }
            }
        }
    }
    // This happens in a background thread!
    private void DeserializeAsync(object json)
    {
        // now it shouldn't matter how long this takes
        var info = JsonUtility.FromJson<SearchInfo>((string)json);
        // dispatch the result back to the main thread
        callbacks.Enqueue(info);
    }
