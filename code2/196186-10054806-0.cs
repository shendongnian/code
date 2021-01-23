    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
          if (e.Button == MouseButtons.Right)
        {
                for (int i = 0; i < tabs.TabCount; ++i)
                    
                    {
                    
                    if (tabs.GetTabRect(i).Contains(e.Location)) 
                         {
                    
                    tabControl1.SelectTab(i);
                    
                    this.contextMenuStrip1.Show(this.tabControl1, e.Location);
                    
                         }
                    
                    }
        }
    }
