    public string Data;
    
    public void LoadData()
    {
        StreamReader LoadWriter = new StreamReader("Assets/SaveData/Savefile.txt");
        //LoadWriter.ReadLine();
        //Data = File.ReadAllText("Assets/SaveData/Savefile.txt");
        Data = LoadWriter.ReadLine();
        print(Data);
        GameObject temp = GameObject.Find("Level").transform.Find(Data).gameObject;
        temp.SetActive(true);
    }
