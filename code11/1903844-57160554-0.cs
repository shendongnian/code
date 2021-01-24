    public static void ShowError(object sender, string text)
    {
        Style style = (Style)this.FindResource("TooltipStyleKey");
        ToolTip errormsg = new ToolTip { Content = text, Style = style };
        ToolTipService.SetShowDuration(errormsg, 3000);
        if (!errormsg.IsOpen)
        {
            errormsg.Opened += async delegate (object o, RoutedEventArgs args)
            {
                var s = o as ToolTip;
                // let the tooltip display for 2 second
                await Task.Delay(1000);
                s.IsOpen = false;
    
                ((FrameworkElement)sender).ToolTip = null;
            };
            errormsg.IsOpen = true;
         }
    }
