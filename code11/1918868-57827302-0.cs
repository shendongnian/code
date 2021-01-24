       <CheckBox
            Content="CheckBox"
            Checked="CheckBox_Checked"
            Unchecked="CheckBox_Unchecked"/>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }
        void Handle(CheckBox checkBox)
        {
           bool checked = checkBox.IsChecked.Value;
        }
