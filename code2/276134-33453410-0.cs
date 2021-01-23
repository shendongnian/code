        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var memtree = new TreeView();
            var rn = treeView1.Nodes[0];
            treeView1.Nodes.Remove(rn);
            memtree.ImageList = treeView1.ImageList;
            memtree.BorderStyle = BorderStyle.None;
            memtree.Nodes.Add(rn);
            memtree.ClientSize = new Size(e.MarginBounds.Width, e.MarginBounds.Height);
            var bmp = new Bitmap(e.MarginBounds.Width, e.MarginBounds.Height);
            memtree.DrawToBitmap(bmp, new Rectangle(0, 0, e.MarginBounds.Width-1, e.MarginBounds.Height-1));
            e.Graphics.DrawImage(bmp, e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width -1, e.MarginBounds.Height -1);
            memtree.Nodes.Remove(rn);
            treeView1.Nodes.Add(rn);
        }
