            for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                var tabRect = this.tabControl1.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var imageRect = new Rectangle(tabRect.Right - CloseImage.Width,
                                         tabRect.Top + (tabRect.Height - CloseImage.Height) / 2,
                                         CloseImage.Width,
                                         CloseImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    if (tabControl1.TabCount > 1)
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        this.tabControl1.SelectedIndex = i - 1; // Added this bit myself, you won't find it in the answer in the link
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
