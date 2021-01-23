    public FormPanel() : this(null)
    {
    }
    public FormPanel(Control parent)
    {
        if (parent != null)
        {
            this.Parent = parent;
        }
        this.Dock = DockStyle.Fill;
        ...
    }
