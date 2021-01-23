    class MainWindow ...
        // a bool with initial value of true
        public static Prop<bool> optionBool { get; set; } = new Prop<bool>{ Value = true };
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // connect UI to be able to use the Prop
            DataContext = this;
        }
