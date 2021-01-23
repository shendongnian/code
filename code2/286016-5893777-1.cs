    public TestView(IStartupPresentationModel startupModel)
    {
       InitializeComponent();
       this.Btn.Click += new EventHandler(Btn_Click);
    }
	void Btn_Click(object sender, EventArgs e)
	{
		this.Btn.Width = 550;
	}
