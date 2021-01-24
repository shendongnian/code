    public static void focus(object sender, EventArgs e)
            {
                var native = (UITextField)sender;
                native.Layer.MasksToBounds = true;
                native.Layer.BorderColor = ColorPalette.LightBlue.CGColor;
                native.BorderStyle = UITextBorderStyle.RoundedRect;
                native.Layer.BorderWidth = 2;
            }
    
            public static void unfocus(object sender, EventArgs e)
            {
                var native = (UITextField)sender;
                native.Layer.MasksToBounds = true;
                native.Layer.BorderWidth = (System.nfloat)0;
            }
