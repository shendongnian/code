        public delegate void ucRadioButtonHandler(object sender, **ucButtonEventArgs** e);
        public event ucRadioButtonHandler onRadioButtonClick;
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (onRadioButtonClick != null)
            {
                onRadioButtonClick(sender, new ucButtonEventArgs());
            }
        }
