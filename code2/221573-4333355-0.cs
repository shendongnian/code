      void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            
            TreeViewHitTestInfo h = treeView1.HitTest(e.Location);
            if (h.Location != TreeViewHitTestLocations.Label && h.Location!= TreeViewHitTestLocations.None )
            {
                treeView1.SelectedNode = null;
            }
        }
