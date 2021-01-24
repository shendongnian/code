    private void Start()
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference path_reference = storage.GetReference("background/1.jpg");
        path_reference.GetValueAsync().ContinueWith(task => 
            {
               Debug.Log("Default Instance entered");
               if (task.IsFaulted)
               {
                   Debug.Log("Error retrieving data from server");
               }
               else if (task.IsCompleted)
               {
                   DataSnapshot snapshot = task.Result;
    
                   string data_URL = snapshot.GetValue(true).ToString();
    
                   //Start coroutine to download image
                   StartCoroutine(DownloadImage(data_URL));
               }
           });
    }
    private IEnumerator DownloadImage(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Instead of accessing the texture
                //var texture = DownloadHandlerTexture.GetContent(uwr);
                // you can directly get the bytes
                var bytes = DownloadHandlerTexture.GetData(uwr);
                // and write them to File e.g. using
                using (FileStream fileStream = File.Open(filename, FileMode.OpenOrCreate))
                {
                    fileStream.WriteAsync(bytes, 0, bytes.Length);
                }
            }
        }
    }
    
