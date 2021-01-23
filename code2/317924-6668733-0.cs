    public void chgnav(string wt, string nav)
    {
            if (nav == "prev")
            {
                pictureBox7.Visible = (wt=="enable");
                pictureBox9.Visible = (wt!="enable");
            }
            else
            {
                pictureBox8.Visible = (wt=="enable");
                pictureBox10.Visible = (wt!="enable");
            }
    }
    
