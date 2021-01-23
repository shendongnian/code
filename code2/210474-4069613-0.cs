        Protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("BoolTest", "False");
        }
    
        Protected Bool test()
        {
              return (bool)Session["BoolTest"].tostring();
        }
