    private readonly BindingList<UserAccess> accessList = new BindingList<UserAccess>();
    public Form1()
    {
        InitializeComponent();
        comboBox1.ValueMember = "AccessId";
        comboBox1.DisplayMember = "Access";
        comboBox1.DataSource = accessList;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        accessList.Add(new UserAccess { AccessId = 1, Access = "Test1" });
        accessList.Add(new UserAccess { AccessId = 2, Access = "Test2" });
    }
