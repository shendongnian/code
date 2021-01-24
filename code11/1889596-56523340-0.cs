    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Random rnd = new Random();
            Ucodelbl.Text = rnd.Next(0, 10000).ToString();
        }
    }
