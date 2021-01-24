    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var senderBtn = sender as Button;
            MessageBox.Show(senderBtn.Content.ToString());
        }
