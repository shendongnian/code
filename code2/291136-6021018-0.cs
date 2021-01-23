    public delegate void ControlButtonClickedHandler(object sender, EventArgs e);
    public event ControlButtonClickedHandler ControlButtonClicked;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnStuff.Click += new EventHandler(btnStuff_Click);
    }
    void btnStuff_Click(object sender, EventArgs e)
    {
        if (ControlButtonClicked != null)
        {
            ControlButtonClicked(sender, e);
        }
    }
