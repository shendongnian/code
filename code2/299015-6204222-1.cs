    protected void btnSubmit_Click(object sender, EventArgs e)        
    {            
        Int32 count = Int32.Parse(this.ViewState["Count"].ToString()) + 1;
        this.ViewState["Count"] = count;
        if (count > 3)
        {
            // Do something ..
        }
    }
