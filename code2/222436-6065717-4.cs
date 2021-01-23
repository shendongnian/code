            private void tabControl_MouseDown(object sender, MouseEventArgs e)
            {
                // store clicked tab
                int hover_index = this.getHoverTabIndex(this.tabControl);
                if (hover_index >= 0) this.tabControl.Tag = this.tabControl.TabPages[hover_index];
            }
            private void tabControl_MouseUp(object sender, MouseEventArgs e)
            {
                // clear stored tab
                this.tabControl.Tag = null;
            }
            private void tabControl_MouseMove(object sender, MouseEventArgs e)
            {
                // mouse button down? tab was clicked?
                if ((e.Button != MouseButtons.Left) || (this.tabControl.Tag == null)) return;
                TabPage clickedTab = (TabPage)this.tabControl.Tag;
                int clicked_index = this.tabControl.TabPages.IndexOf(clickedTab);
               
                // start drag n drop
                this.tabControl.DoDragDrop(clickedTab, DragDropEffects.All);              
            }
            private void tabControl_DragOver(object sender, DragEventArgs e)
            {
                // a tab is draged?
                if (e.Data.GetData(typeof(TabPage)) == null) return;
                TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
                int dragTab_index = this.tabControl.TabPages.IndexOf(dragTab);
                // hover over a tab?
                int hoverTab_index = this.getHoverTabIndex(this.tabControl);                
                if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
                TabPage hoverTab = this.tabControl.TabPages[hoverTab_index];
                e.Effect = DragDropEffects.Move;
                // start of drag?
                if (dragTab == hoverTab) return;
                // swap dragTab & hoverTab - avoids toggeling
                Rectangle dragTabRect = this.tabControl.GetTabRect(dragTab_index);
                Rectangle hoverTabRect = this.tabControl.GetTabRect(hoverTab_index);
                if (dragTabRect.Width < hoverTabRect.Width) {                                        
                    Point tcLocation = this.tabControl.PointToScreen(this.tabControl.Location);
               
                    if (dragTab_index < hoverTab_index) {
                        if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                            this.swapTabPages(this.tabControl, dragTab, hoverTab);
                    } else if (dragTab_index > hoverTab_index) {
                        if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                            this.swapTabPages(this.tabControl, dragTab, hoverTab);
                    }
                } else this.swapTabPages(this.tabControl, dragTab, hoverTab); 
                // select new pos of dragTab
                this.tabControl.SelectedIndex = this.tabControl.TabPages.IndexOf(dragTab);
            }
            private int getHoverTabIndex(TabControl tc)
            {
                for (int i = 0; i < tc.TabPages.Count; i++)
                {
                    if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                        return i;
                }
                return -1;
            }
            private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
            {
                int index_src = tc.TabPages.IndexOf(src);
                int index_dst = tc.TabPages.IndexOf(dst);
                tc.TabPages[index_dst] = src;
                tc.TabPages[index_src] = dst;
                tc.Refresh();
            }
