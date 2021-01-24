    private SqlConnection con;
    public Form1()
    {
        InitializeComponent();
        con = new SqlConnection(@"Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"{0}\";Integrated Security=True;Connection Timeout=10;User Instance=True;MultipleActiveResultSets=True;");
        con.Open();
    }
