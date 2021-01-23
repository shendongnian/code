    private void cBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cBox = sender as ComboBox;
            Popup popup = (Popup)cBox.Template.FindName("PART_Popup", cBox);
            popup.PopupAnimation = PopupAnimation.Fade;
        }
