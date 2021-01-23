    private readonly int _index;
    public TabbedForm(int index)
    {
      this._index = index;
      InitializeComponent();
    }
    private void form_Load(object sender, EventArgs e)
    {
      for (int index = this.tabControl1.TabPages.Count - 1; index >= 0; index--)
      {
        if (index != this._index)
          this.tabControl1.TabPages.Remove(this.tabControl1.TabPages[index]);
      }
    }
