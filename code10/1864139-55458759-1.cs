    private void LoadGameData()
	{
		#if UNITY_EDITOR
		string filePath = Path.Combine (Application.streamingAssetsPath, gameDataFileName);
			if (File.Exists (filePath)) {
				string dataAsJson = File.ReadAllText (filePath);
				GameData loadedData = JsonUtility.FromJson<GameData> (dataAsJson);
				allRoundData = loadedData.allRoundData;
			} else 
			{
				Debug.LogError ("Cannot load game data!");
			}
		#elif UNITY_ANDROID
			string path = Application.streamingAssetsPath + "/data.json";
			WWW www = new WWW(path); 
			while(!www.isDone){}
			string dataAsJson1 = www.text;
			GameData loadedData1 = JsonUtility.FromJson<GameData> (dataAsJson1);
			allRoundData = loadedData1.allRoundData;
		#endif
	}
