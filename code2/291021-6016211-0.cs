    private void toolStripMenuItem_Click(object sender, EventArgs e)    
    {        
         ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem) sender;
         switch (toolStripMenuItem.ID)
         {
             case "toolStripMenuItem4":
             {
                  CurrentPanel.PenThickness = 3;    
                  break;
             }
             ..........
             ..........
         }
    }
