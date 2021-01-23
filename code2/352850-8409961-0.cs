    private void layoutroot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
                   //clear the auto selected control
            if (this.SelectedControl != null 
                && sender is Canvas && e.OriginalSource is Canvas)
            {
                if ((sender as Canvas).Equals(( e.OriginalSource as Canvas)))
                {
                    this.SelectedControl = null;
                }
            }
        }
 
