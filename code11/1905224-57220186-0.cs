    void Awake()
        {
            
            filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "CountryCodes2.json");
        
                 StartCoroutine(Example());  
        }
       
        IEnumerator Example() 
        {
            if (filePath.Contains("://")) 
            {
                UnityWebRequest www = new UnityWebRequest(filePath);
                yield return www.SendWebRequest();
                result = www.downloadHandler.text;
            }
            else
                result = System.IO.File.ReadAllText(filePath);
    
         }
