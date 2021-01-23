            private void tc_MouseDown(object sender, MouseEventArgs e)
            {
                // store clicked tab
                TabControl tc = (TabControl)sender;
                int hover_index = this.getHoverTabIndex(tc);
                if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
            }
            private void tc_MouseUp(object sender, MouseEventArgs e)
            {
                // clear stored tab
                TabControl tc = (TabControl)sender;
                tc.Tag = null;
            }
            private void tc_MouseMove(object sender, MouseEventArgs e)
            {           
                // mouse button down? tab was clicked?
                TabControl tc = (TabControl)sender;
                if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
                TabPage clickedTab = (TabPage)tc.Tag;
                int clicked_index = tc.TabPages.IndexOf(clickedTab);
                // start drag n drop
                tc.DoDragDrop(clickedTab, DragDropEffects.All);
            }
            private void tc_DragOver(object sender, DragEventArgs e)
            {
                TabControl tc = (TabControl)sender;
                // a tab is draged?
                if (e.Data.GetData(typeof(TabPage)) == null) return;
                TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
                int dragTab_index = tc.TabPages.IndexOf(dragTab);
                // hover over a tab?
                int hoverTab_index = this.getHoverTabIndex(tc);
                if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
                TabPage hoverTab = tc.TabPages[hoverTab_index];
                e.Effect = DragDropEffects.Move;
                // start of drag?
                if (dragTab == hoverTab) return;
                // swap dragTab & hoverTab - avoids toggeling
                Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
                Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);
                if (dragTabRect.Width < hoverTabRect.Width)
                {
                    Point tcLocation = tc.PointToScreen(tc.Location);
                    if (dragTab_index < hoverTab_index)
                    {
                        if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                            this.swapTabPages(tc, dragTab, hoverTab);
                    }
                    else if (dragTab_index > hoverTab_index)
                    {
                        if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                            this.swapTabPages(tc, dragTab, hoverTab);
                    }
                }
                else this.swapTabPages(tc, dragTab, hoverTab);
                // select new pos of dragTab
                tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
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
