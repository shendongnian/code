    class Eco {
      public Eco() { }
      public void SetEcoValues(string text, double value) {
        Text = text;
        Value = value;
      }
      public string Text { get; set; }
      public double Value { get; set; }
      public override string ToString() {
        if (!String.IsNullOrEmpty(Text)) {
          return Text;
        }
        return base.ToString();
      }
    }
    ListView listView1; // initialized somewhere, I presume.
    void Update_Click(object sender, EventArgs e) {
      if ((listView1.SelectedItems != null) || (0 < listView1.SelectedItems.Count)) {
        ListViewItem item = listView1.SelectedItems[0];
        Eco y = item.Tag as Eco;
        if (y == null) {
          y = new Eco();
        }
        y.SetEcoValues(textBox1.Text, Convert.ToDouble(textBox2.Text));
        item.Text = y.Text;
        if (item.SubItems.Count < 2) {
          item.SubItems.Add(y.Value.ToString());
        } else {
          item.SubItems[1].Text = y.Value.ToString();
        }
        item.Tag = y;
      }
    }
