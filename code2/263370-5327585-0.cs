    private void GridViewColumnHeader_Loaded(object sender, RoutedEventArgs e)
        {            
            GridViewColumnHeader columnHeader = sender as GridViewColumnHeader;
            Border HeaderBorder = columnHeader.Template.FindName("HeaderBorder", columnHeader) as Border;
            if (HeaderBorder != null)
            {
                HeaderBorder.Background = HeaderBorder.Background;
            }
            Border HeaderHoverBorder = columnHeader.Template.FindName("HeaderHoverBorder", columnHeader) as Border;
            if (HeaderHoverBorder != null)
            {
                HeaderHoverBorder.BorderBrush = HeaderHoverBorder.BorderBrush;
            }
            Rectangle UpperHighlight = columnHeader.Template.FindName("UpperHighlight", columnHeader) as Rectangle;
            if (UpperHighlight != null)
            {
                UpperHighlight.Visibility = UpperHighlight.Visibility;
            }
            Thumb PART_HeaderGripper = columnHeader.Template.FindName("PART_HeaderGripper", columnHeader) as Thumb;            
            if (PART_HeaderGripper != null)
            {
                PART_HeaderGripper.Background = PART_HeaderGripper.Background;
                PART_HeaderGripper.Cursor = System.Windows.Input.Cursors.Arrow; // override the size curser
            }
        }
