    ...
    
    private string InitialValue1 
    { 
        get { return ViewState[@"IV1"] as string; } 
        set { ViewState[@"IV1"] = value; }
    }
    // Repeat for all 32 text boxes.
    
    protected void Page_Load( object sender, EventArgs e )
    {
        if(!IsPostBack )
        {
            TextBox1.Text = InitialValue1 = loadText1FromDatabase();
            // Repeat for all 32 text boxes.
        }
    }
    protected void MySaveButton_Click( object sender, EventArgs e )
    {
        if ( TextBox1.Text!=InitialValue1 ) saveText1ToDatabase( TextBox1.Text );
        // Repeat for all 32 text boxes.
    }
    ...
