    IEnumerator DownloadImage(string address, string fileName)
    {
        var local_path = Application.persistentDataPath + THUMBNAILS_PATH;
        var content_ref = m_storage_ref.Child(THUMBNAILS_PATH + fileName + ".png");
    
        content_ref.GetFileAsync(local_path).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("File downloaded.");
            }
            else
            {
                Debug.Log(task.Exception.ToString());
            }
        });
    
        yield return null;
    }
 
