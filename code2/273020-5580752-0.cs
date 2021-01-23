     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListBox1.DataSource = GetList();
                ListBox1.DataBind();
            }
        }
    
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox2.DataSource = GetSecondList(ListBox1.SelectedIndex);
            ListBox2.DataBind();
        }
    
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox3.Items.Add(new ListItem(ListBox1.SelectedValue + "-" + ListBox2.SelectedValue, "Wippie"));
        }
    
        private ListItemCollection GetList()
        {
            ListItemCollection lstNumbers = new ListItemCollection();
            lstNumbers.Add(new ListItem("1", "One"));
            lstNumbers.Add(new ListItem("2", "Two"));
            lstNumbers.Add(new ListItem("3", "Three"));
            lstNumbers.Add(new ListItem("4", "Four"));
            lstNumbers.Add(new ListItem("5", "Five"));
            return lstNumbers;
        }
    
        private ListItemCollection GetSecondList(int iSelectedIndex)
        {
            ListItemCollection lstRandom = new ListItemCollection();
            System.Random RandNum = new System.Random();
            for (int i = 0; i < 10; i++)
            {
                lstRandom.Add(new ListItem(RandNum.Next(ListBox1.SelectedIndex, i + 1).ToString(), "random"));
            }
            return lstRandom;
        }
