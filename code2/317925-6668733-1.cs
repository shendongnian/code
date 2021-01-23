    public void chgnav(string wt, string nav)
    {
        (nav=="prev" ? pictureBox7 : pictureBox8).Visible = (wt=="enable");
        (nav=="prev" ? pictureBox9 : pictureBox10).Visible = (wt!="enable");
    }
