    public Form1() {
        InitializeComponent();
    }
    private async void Form1_Load(object sender, EventArgs e) {
        //On UI thread
        resultsLoadedLabel.Text = "Loading data!";
        //get data on separate thread (non blocking)
        List<Result> results = await GetResults.GetDataAsync("http://worldcup.sfg.io/teams/results/");
        //Back on UI thread
        resultsLoadedLabel.Text = "Podaci učitani!";
        foreach (var result in results) {
            ResultBox.Items.Add(result.Fifa_Code);
        }
    }
