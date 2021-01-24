            public MainWindow()
            {
                InitializeComponent();
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Conversion();
            }
            private void ConvertSecondsToHoursMinutesSecondsMethod(int totalSeconds, ref long hours, ref long secs, ref long min)
            {
                long v;
                hours = totalSeconds / 3600;
                v = totalSeconds % 3600;
                min = v / 60;
                secs = v % 60;
            }
            private void Conversion()
            {
                long hours = 0;
                long secs = 0;
                long mins = 0;
                int seconds = Convert.ToInt32(userInputLabel.Text);
    
                ConvertSecondsToHoursMinutesSecondsMethod(seconds, ref hours, ref mins, ref secs);
    
                outputLabel.Content = $"{hours} {mins} {secs}";
            }
