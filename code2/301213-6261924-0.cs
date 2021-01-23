    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!Page.IsPostBack)  
        {    
            RadComboBoxItem item1 = new RadComboBoxItem();    
            item1.Text = "Item1";   
            item1.Value = "1";    
            RadComboBox1.Items.Add(item1);    
            RadComboBoxItem item2 = new RadComboBoxItem();   
            item2.Text = "Item2";    
            item2.Value = "2";   
            RadComboBox1.Items.Add(item2);    
            RadComboBoxItem item3 = new RadComboBoxItem();    
            item3.Text = "Item3";   
            item3.Value = "3";   
            RadComboBox1.Items.Add(item3);  
        }
    }
