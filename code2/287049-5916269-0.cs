    void lnk_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
    
        if (btn != null)
        {
            String id = btn.ID;
            //etc
        }
    }
