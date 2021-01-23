      private void pbxpurchase_Click(object sender, EventArgs e)
        {
            contentpnl.Controls.Clear();//contentpnl is the panelname
            purchasebook purchasebk = new purchasebook();//purchasebook is a formname
            purchasebk.TopLevel = false;
            purchasebk.AutoScroll = true;
            contentpnl.Controls.Add(purchasebk);
            purchasebk.Dock = DockStyle.Fill;
            purchasebk.Show();
                
        }
