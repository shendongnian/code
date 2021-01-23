    private void Main_clientImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  
    {  
        showMenu.Visibility = Visibility.Visible;  
        homeMenu.Visibility = Visibility.Hidden;
        setTabSelected("showMenu");  
    }   
    
    public void setTabSelected(String name)  
    {  
        for (int i = 0; i < tabControl.Items.Count; i++)  
        {  
            TabItem item = tabControl.Items.GetItemAt(i) as TabItem;  
            if (item.Header.Equals(name))  
            {  
                selectedTab = i;  
                item.IsSelected = true; 
                item.Foreground = new SolidColorBrush(Colors.Black);  
            }
            else  
            {  
                item.Foreground = new SolidColorBrush(Colors.White);  
            }  
        }  
    }  
    
    private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        for (int i = 0; i < tabControl.Items.Count; i++)
        {
            TabItem item = tabControl.Items.GetItemAt(i) as TabItem;
            if (tabControl.SelectedIndex == i)
            {
                item.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                item.Foreground = new SolidColorBrush(Colors.White);
            }
        }
    }
