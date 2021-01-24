    ToolTip ToolTip = new ToolTip();
    ToolTip.OwnerDraw = true;
    ToolTip.Popup += (ss, ee) => { ee.ToolTipSize = new Size(200, 50);  };
    ToolTip.Draw += (ss, ee) =>
    {
        ee.DrawBackground();
        ee.DrawBorder();
        ee.Graphics.DrawString("Warning", Font, Brushes.Red, 10, 1);
        ee.Graphics.DrawString(ee.ToolTipText, Font, Brushes.Black, 1, 22);
    };
    ToolTip.Show("Demo only", somecontrol..);
