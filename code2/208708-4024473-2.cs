    protected void Page_Load(object sender, EventArgs e) 
        { 
            if (!Page.IsPostBack) 
            { 
                //ddlProducts.Items.Insert(0, new ListItem("Products", "0")); 
            } 
            productLabel.Text = "Product name"; 
            newProductButton.Text = "Add product"; 
            ProductName = productText.Text; 
     
            ddlProducts.SelectedIndexChanged += ddlProducts_SelectedIndexChanged;
        } 
