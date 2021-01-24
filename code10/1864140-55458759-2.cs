    private void LoadGameData()
	{
        StartCoroutine(GetText());
    }
    IEnumerator GetText()
    {
        string path = Application.streamingAssetsPath + "/data.json";
        UnityWebRequest www = UnityWebRequest.Get(path);
        yield return www.SendWebRequest();
        Debug.Log("Loaded Q's");
        string dataAsJson1 = www.downloadHandler.text;
        GameData loadedData1 = JsonUtility.FromJson<GameData>(dataAsJson1);
        allRoundData = loadedData1.allRoundData;
        
    }
