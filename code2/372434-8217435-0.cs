    private ListBox listBox1;
    public Form1()
    {
      InitializeComponent();
      listBox1 = new ListBox();
      listBox1.IntegralHeight = false;
      listBox1.MinimumSize = new Size(120, 120);  \\ <- important
      listBox1.Items.Add("Item 1");
      listBox1.Items.Add("Item 2");
    }
    private void toolStripSplitButton1_DropDownOpening(object sender, EventArgs e) {
      ToolStripControlHost toolHost = new ToolStripControlHost(listBox1);
      toolHost.Size = new Size(120, 120);
      toolHost.Margin = new Padding(0);
      ToolStripDropDown toolDrop = new ToolStripDropDown();
      toolDrop.Padding = new Padding(0);
      toolDrop.Items.Add(toolHost);
      toolDrop.Show(this, new Point(toolStripSplitButton1.Bounds.Left,
                                    toolStripSplitButton1.Bounds.Bottom));
    }
