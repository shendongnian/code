    void Start()
    {
       
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        print("Streaming Assets Path: " + Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("*.*");
        foreach (FileInfo file in allFiles)
        {
            if (file.Name.Contains("player1"))
            {
                StartCoroutine("LoadPlayerUI", file);
            }          
        }     
    }
    IEnumerator LoadPlayerUI(FileInfo playerFile)
    {
        //1
        if (playerFile.Name.Contains("meta"))
        {
            yield break;
        }
        //2
        else
        {
            string playerFileWithoutExtension = Path.GetFileNameWithoutExtension(playerFile.ToString());
            string[] playerNameData = playerFileWithoutExtension.Split(" "[0]);
            //3
            string tempPlayerName = "";
            int i = 0;
            foreach (string stringFromFileName in playerNameData)
            {
                if (i != 0)
                {
                    tempPlayerName = tempPlayerName + stringFromFileName + " ";
                }
                i++;
            }
            //4
            string wwwPlayerFilePath = "file://" + playerFile.FullName.ToString();
            WWW www = new WWW(wwwPlayerFilePath);
            yield return www;
            //5
            playerAvatar.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            playerName.text = tempPlayerName;
           
        }
    }
    void Update()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        print("Streaming Assets Path: " + Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("*.*");
        foreach (FileInfo file in allFiles)
        {
            if (file.Name.Contains("player1"))
            {
                StartCoroutine("LoadPlayerUI", file);
            }
        }
    }
