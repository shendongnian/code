    private List<int> entries = new List<int>();
    public Form1() {
      InitializeComponent();
      entries.Add(3);
      entries.Add(4);
      entries.Add(3);
      listBox1.DrawMode = DrawMode.OwnerDrawVariable;
      listBox1.MeasureItem += new MeasureItemEventHandler(listBox1_MeasureItem);
      listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);
    }
    private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e) {
      if (e.Index > -1)
        e.ItemHeight = (((int)listBox1.Items[e.Index]) * 16) + 8;    
    }
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e) {
      e.DrawBackground();
      if (e.Index > -1) {
        ControlPaint.DrawBorder3D(e.Graphics, e.Bounds);
        for (int i = 0; i < (int)listBox1.Items[e.Index]; i++) {
          TextRenderer.DrawText(e.Graphics,
                                "Item #" + i.ToString(),
                                e.Font,
                                new Point(e.Bounds.Left + 4, (e.Bounds.Top + 4) + (i * 16)),
                                Color.Black);
        }
      }
    }
