    public void chgnav(string wt, string nav)
    {
       bool wtEnabled = wt == "enable";
       if (nav == "prev")
       {
          pictureBox7.Visible = wtEnabled;
          pictureBox9.Visible = !wtEnabled;
       }
       else
       {
          pictureBox8.Visible = !wtEnabled;
          pictureBox10.Visible = wtEnabled;
       }
    }
