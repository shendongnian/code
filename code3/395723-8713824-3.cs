    public ChildForm()
    {
        ...
        FormClosing += new FormClosingEventHandler(ChildForm_FormClosing);
    }
    void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
