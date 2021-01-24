    public MainPage()
    {
        InitializeComponent();
        //iOS
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "iOSTest.db");
        // Android
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AndroidTest.db");
        // Create Database & Tables
        using (var db = new DatabaseContext(dbPath))
        {
            db.Database.EnsureCreated();
            // Insert Data
            db.Add(new Participant() { Fname = "time: " + DateTime.Now.ToString() });
            db.SaveChanges();
            // Retrieve Data
            // Next two lines receive error in scenario 2
            var result2 = db.Participants.Where(xyz => xyz.Id == 1).ToList();
            IEnumerable<Participant> p = db.Participants.ToList();
        }
    }
