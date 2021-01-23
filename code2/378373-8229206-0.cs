    private ToolTip toolTip1;
    public UserControl1() {
      InitializeComponent();
      // tooltip initialization
      this.Disposed += UserControl1_Disposed;
    }
    private void UserControl1_Disposed(object sender, EventArgs e) {
      if (toolTip1 != null)
        toolTip1.Dispose();
    }
