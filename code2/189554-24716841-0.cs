    private void ShowTooltipBalloon(string title, string msg)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new EventHandler(delegate { ShowTooltipBalloon(title, msg); }));
        }
        else
        {
            // the designer hooks up to this.components
            // so lets do that as well...
            ToolTip tt = new ToolTip(this.components);
            
            tt.IsBalloon = true;
            tt.ToolTipIcon = ToolTipIcon.Warning;
            tt.ShowAlways = true;
            tt.BackColor = Color.FromArgb(0xFF, 0xFF, 0x90);
            tt.ToolTipTitle = title;
            
            // Hookup this tooltip to the statusStrip control
            // but DON'T set a value 
            // because if you do it replicates the problem in your image
            tt.SetToolTip(this.statusStrip1, String.Empty); 
    
            // calc x
            int x = 0;
            foreach (ToolStripItem tbi in this.statusStrip1.Items)
            {
                // find the toolstrip item
                // that the tooltip needs to point to
                if (tbi == this.toolStripDropDownButton1)  
                {
                    break;
                }
                x = x + tbi.Size.Width;
            }
    
            // guestimate y 
            int y = -this.statusStrip1.Size.Height - 50;
            // show it using the statusStrop control 
            // as owner
            tt.Show(msg, this.statusStrip1, x, y, 5000);
        }
    }
