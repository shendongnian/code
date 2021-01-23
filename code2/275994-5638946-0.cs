    public MyControl(){
        this.Label.Init += 
            (sender, e) => this.Label.Text = 
                 ((TextBox)Page.FindControl("SomeControl")).Text;
    }
