    namespace MyNameSpace
    {
    
        public static class PropertyGridHelper
        {
    
            private static PropertyGrid getPropertyGridParent(object sender)
            {
                PropertyGrid propertyGrid = null;
                ToolStripButton toolStripButton = sender as ToolStripButton;
    
                // ToolStripButton -> ToolStrip -> PropertyGrid
                if (toolStripButton != null)
                {
                    ToolStrip toolStrip = toolStripButton.GetCurrentParent() as ToolStrip;
    
                    if (toolStrip != null)
                    {
                        propertyGrid = toolStrip.Parent as PropertyGrid;
    
                        if (propertyGrid != null)
                        {
                            propertyGrid.CollapseAllGridItems();
                        }
                    }
                }  
                return propertyGrid;
            }
    
            private static void propertyGridCollapseAllClick(object sender, EventArgs e)
            {
                PropertyGrid propertyGrid = getPropertyGridParent(sender);
    
                if (propertyGrid != null)
                {
                    propertyGrid.CollapseAllGridItems();
                }         
            }
    
            private static void propertyGridExpandAllClick(object sender, EventArgs e)
            {
                PropertyGrid propertyGrid = getPropertyGridParent(sender);
    
                if (propertyGrid != null)
                {
                    propertyGrid.ExpandAllGridItems();
                }
            }
    
            public static void AddCollapseExpandAllButtons(this System.Windows.Forms.PropertyGrid propertyGrid)
            {
    
                foreach (Control control in propertyGrid.Controls)
                {
                    ToolStrip toolStrip = control as ToolStrip;
    
                    if (toolStrip != null)
                    {
                        toolStrip.Items.Add(new ToolStripButton("", Properties.Resources.CollapseAll, propertyGridCollapseAllClick));
                        toolStrip.Items.Add(new ToolStripButton("", Properties.Resources.ExpandAll, propertyGridExpandAllClick));
                    }
                }
            }
         }
     }
