    MyUserSettings mus;
    
    private void Form1_Load(object sender, EventArgs e)
    {
        mus = new MyUserSettings();
        mus.BackgroundColor = Color.AliceBlue;
        this.DataBindings.Add(new Binding("BackColor", mus, "BackgroundColor"));
    }
    void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        mus.Save();
    }
