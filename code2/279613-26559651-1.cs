        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            
            switch(tabItem)
            {
                case "Item1":
                    break;
                
                case "Item2":
                    break;
                
                case "Item3":
                    break;
                default:
                    return;
            }
        }
