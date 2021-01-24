        private void RadioButton_Checked(object sender, RoutedEventArgs e)            
        {
            RadioButton radio = (RadioButton)sender;
            {}
            if (radio != null)
            {
                String selected = radio.Tag.ToString();
                switch (selected)
                {
                    default:
                    case "Red":
                        Title.Foreground = new SolidColorBrush(Colors.Red);
                        MainPage.Current.Subject1.Foreground = new SolidColorBrush(Colors.Red);
                        break;`
