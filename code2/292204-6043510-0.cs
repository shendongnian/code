    private void Button_Click(object sender, RoutedEventArgs e)
            {
              Button clickedButton = sender as Button;
              ListViewItem holderItem = clickedButton.Parent as ListViewItem;
              Console.WriteLine("You are clicked the buton in " + holderItem.Name);
            }
