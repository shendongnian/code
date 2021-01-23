    private void changeTypeToToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
      ToolStripMenuItem mi = sender as ToolStripMenuItem;
      if (mi != null) {
        // This is your text:
        Console.WriteLine(mi.Text);
      }
    }
