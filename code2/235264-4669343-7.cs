        toolTip = new ToolTip();
        toolTip.OwnerDraw = true;
        toolTip.Draw += new DrawToolTipEventHandler(tooltip_Draw);
        toolTip.Popup += new PopupEventHandler(tooltip_Popup);    
        toolTip.UseAnimation = true;
        toolTip.AutoPopDelay = 500;
        toolTip.AutomaticDelay = 500;
