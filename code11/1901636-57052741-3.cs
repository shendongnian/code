    public void legitOpen(string nameOfFile)
    {
    }
    private IEnumerator legitOpenRoutine(string nameOfFile)
    {
        string realPath = Path.Combine(Application.persistentDataPath, nameOfFile + ".pdf");
        if (!System.IO.File.Exists(realPath))
        {
            if (!System.IO.Directory.Exists(Path.Combine(Application.persistentDataPath, "PDFs"))
            {
                System.IO.Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "PDFs"));
            }
            using (var reader = new UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, "PDFs", nameOfFile + ".pdf")
            {
                yield return reader.SendWebRequest();
                if (webRequest.isNetworkError)
                {
                    Debug.Log(pages[page] + ": Error: " + webRequest.error);
                    return;
                }                
                System.IO.File.WriteAllBytes(realPath, reader.bytes);
            }
            
            
        }
        Application.OpenURL(realPath);
    }
    
