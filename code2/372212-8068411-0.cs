    private void Control_MouseHover ( object sender, EventArgs e ) {
        if ( inHelpMode ) {
            var c = (Control)sender;
            var rect = c.Bounds;
            rect.Inflate(1,1);
            var g = CreateGraphics ();
            ControlPaint.DrawBorder ( g, rect, Color.Blue, ButtonBorderStyle.Solid );
        }
    }
