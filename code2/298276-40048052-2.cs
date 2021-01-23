    public form1()
    {
        foreach (Panel pl  in Container.Components)
        {
            pl.Click += Panel_Click;
        }
    }
    private void Panel_Click(object sender, EventArgs e)
    {
        // Process the panel clicks here
        int index = Panels.FindIndex(a => a == sender);
        ...
    }
