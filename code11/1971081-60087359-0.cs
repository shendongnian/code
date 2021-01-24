       private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if(player%2==0)
            {
                button.Content = "X";
                player++;
                turns++;
            }
            else
            {
                button.Content= "O";
                player++;
                turns++;
            }
        }
