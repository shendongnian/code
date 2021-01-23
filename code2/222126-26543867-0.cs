    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [Category("Main")]
    [Description("...")]
    [DefaultValue(MyDataClass.None)]
    public MyDataClass Data
    {
      get
      {
        return this.data;
      }
      set
      {
        if (object.ReferenceEquals(value, null))
          value = MyDataClass.None; // not null - valid state of no data
        if (this.Created)
        {
          this.textEdit.Text = value.ToString();
        }
        this.data = value;
      }
    }
    protected override void OnVisibleChanged(EventArgs e)
    {
      base.OnVisibleChanged(e);
      if (!this.DesignMode)
        this.Data = this.data;
    }
