     string[] row = new string[] { "1", "2", "3" };
                System.Windows.Controls.ListView lv = new System.Windows.Controls.ListView();
                lv.Margin = new Thickness(365, 180, 0, 0);
                lv.Height = 100;
                lv.Width = 100;
                lv.ItemsSource = row;
                MainGrid.Children.Add(lv);
