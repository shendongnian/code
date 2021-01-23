     panel.Visible = false;
     while (panel.Controls.Count > 0)
     {
        panel.Controls[0].Dispose();
     }
     panel.Visible = true;
