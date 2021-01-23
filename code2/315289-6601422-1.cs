     <Border Name="border" ToolTip="some message" MouseEnter="border_MouseEnter" Background="red" Margin="50"/>
    
      ToolTip tool = new ToolTip();
            private void border_MouseEnter(object sender, MouseEventArgs e)
            {
            tool.Placement = PlacementMode.Relative;
            tool.HorizontalOffset = 100; 
            tool.VerticalOffset = 200;
            tool.Content = "stuffs";
            tool.IsOpen = true;
            border.ToolTip = tool;
            ToolTipService.SetShowDuration(border, 5000);
            }
