        void tooltip_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(toolTipText, new Font("Courier New", 10.0f, FontStyle.Bold));
        	e.ToolTipSize = new Size(e.ToolTipSize.Width + TOOLTIP_XOFFSET, e.ToolTipSize.Height + TOOLTIP_YOFFSET);
        }
