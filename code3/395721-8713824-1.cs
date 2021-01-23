    public ChildForm()
    {
        ...
        FormClosing += FormClosing;
    }
    void FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
