    private void TabControlSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if(this.allTabItemsChecked==false)
        {
            int index = tabControl.SelectedIndex;
            List<TabItem> list = new List<TabItem>();
            list.AddRange(tabControl.Items.OfType<TabItem>());
            if (index < list.Count()-1)
            {
                tabControl.SelectedIndex = index + 1;
            }
            else
            {
                this.allTabItemsChecked = true;
                tabControl.SelectedIndex = 0;
            }
            contexte.TabControlWidth = Math.Max(tabControl.ActualWidth, contexte.TabControlWidth);
            contexte.TabControlHeight = Math.Max(tabControl.ActualHeight, contexte.TabControlHeight);
    
        }
    }
