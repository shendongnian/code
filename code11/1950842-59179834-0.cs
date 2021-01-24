    [SerializeField] Button increaseButton;
    [SerializeField] Button decreaseButton;
    private void Start()
    {
        m_ButtonRun.onClick.AddListener(TaskOnClick);
        increaseButton.onClick.AddListener(IncreaseLimit);
        decreaseButton.onClick.AddListener(DecreaseLimit);
    }
    private int limit = 1;
    public void IncreaseLimit()
    {
        limit++;
    }
    public void DecreaseLimit()
    {
        limit--;
        limit = Mathf.Max(limit, 1);
    }
    public void TaskOnClick() //
    {
        string connectionString = "myconnection";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("mydb");
        //var database = server.GetDatabase("WIVEmydbData");
        var collection = database.GetCollection<BsonDocument>("mycollection");
        var sort = Builders<BsonDocument>.Sort.Descending("Time");
        var document = collection.Find(new BsonDocument()).Sort(sort).Limit(limit).ForEachAsync(d => Console.WriteLine(d));
        Console.WriteLine(document.ToString());
        //streamwriter writes the Console.WriteLine to multi-import.txt
        FileStream filestream = new FileStream("import.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        var writeFile = new StreamWriter(filestream);
        {
            writeFile.AutoFlush = true;
            Console.SetOut(writeFile);
            writeFile.Write(document.ToString());
        }
    }
    
