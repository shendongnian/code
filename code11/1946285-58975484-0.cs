    void pullAllData()
    {
        int allDaysCount = 10;
        List<int> sensorIds; // initialized with some ids
        // start the "parent" Coroutine
        StartCoroutine(GetAllData(allDaysCount, sensorIds));
    }
    IEnumerator GetAllData(int allDaysCount, List<int> sensorIds)
    {
        for(int i = 0; i < allDaysCount - 1; i++)
        {
            for(int j = 0; j < sensorIds.Count; j++)
            {
                // Simply run and wait for this IEnumerator
                yield return GetDataRequest(i, i + 1, sensorIds[j]);
                // show whats been pulled
                print(this.tempText);
                // parse json string this.tempText etc.
            }
        }
        // Maybe do something when all requests are finished and handled
    }
    IEnumerator GetDataRequest(string currentDateString, string nextDateString, string sensorID)
    {
        string requestParam = "myparameters: " + nextDateString + sensorID; // simplified dummy parameters
        using (UnityWebRequest webRequest = UnityWebRequest.Get(requestParam))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + jwtToken);
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();
            // from unity api example
            string[] pages = getUri.Split('/');
            int page = pages.Length - 1;
            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
            // getting the data i pulled out of the coroutine for further manipulation
            this.tempText = webRequest.downloadHandler.text;
            // show whats been pulled
            print(this.tempText);
        }
    }
    
