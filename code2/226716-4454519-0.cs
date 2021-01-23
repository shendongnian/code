    void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             int index = this.listBox1.IndexFromPoint(e.Location);
             if (index != System.Windows.Forms.ListBox.NoMatches)
                {
                  MessageBox.Show(index.ToString());
                }
         }
