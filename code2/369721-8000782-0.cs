	public ArrayList  Numbers
	{
		get
		{
			return (ArrayList)this.ViewState["Numbers"];
		}
		set
		{
			this.ViewState["Numbers"] = value;
		}
	}
	protected override void OnInit(EventArgs e)
	{
		this.btnRemove.Click += new EventHandler(btnRemove_Click);
		base.OnInit(e);
	}
	void btnRemove_Click(object sender, EventArgs e)
	{
		this.Numbers.RemoveAt(Convert.ToInt32(this.ddlNumbers.SelectedValue));
		this.BindList();
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			this.Numbers = new ArrayList();
			for (int i = 0; i < 10; i++)
			{
				this.Numbers.Add(i);
			}
			this.BindList();
		}
	}
	private void BindList()
	{
		this.ddlNumbers.Items.Clear();
		for (int i = 0; i < this.Numbers.Count; i++)
		{
			this.ddlNumbers.Items.Add((i + 1).ToString());
		}
	}
