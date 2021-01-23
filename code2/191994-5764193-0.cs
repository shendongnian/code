     private void tabControlName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl) //if this event fired from TabControl then enter
            {
                if (tabItemName.IsSelected)
                {
                    //Do your job here
                }
            }
        }
