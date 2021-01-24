        private void tabBrowser_DrawItem(object sender, DrawItemEventArgs e)
        {
            // always draw the tab text:
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabRect, tabPage.ForeColor, TextFormatFlags.Left);
            // only draw the X if we are not the first tab:
            if (e.Index > 0)
            {
                var tabPage = this.tabBrowser.TabPages[e.Index];
                var tabRect = this.tabBrowser.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                var closeImage = Properties.Resources.closeicon;
                e.Graphics.DrawImage(closeImage, (tabRect.Right - closeImage.Width), tabRect.Top + (tabRect.Height - closeImage.Height) / 2);       
            }     
        }
