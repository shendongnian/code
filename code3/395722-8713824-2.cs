    public ChildForm()
    {
        ...
        FormClosing += new FormClosingEventHandler(FormClosing);
    }
    void FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
