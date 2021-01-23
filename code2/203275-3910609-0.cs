    public void eins_Click(object sender, RoutedEventArgs e)
        {
            var _sender = sender as CheckBox;
            if (_sender.Tag == null || _sender.Tag.ToString() != "pressedOnce")
            {
                _sender.Tag = "pressedOnce";
                _sender.IsChecked = false;
                testStack.Children.Remove(_sender);
                Border border = new Border()
                {
                    BorderThickness = new Thickness(2),
                    BorderBrush = new SolidColorBrush(Colors.Cyan),
                };
                border.Child = _sender;
                testStack.Children.Insert(0, border);
            }
            else
            {
                _sender.IsChecked = true;
            }
        }
        private void eins_LostFocus(object sender, RoutedEventArgs e)
        {
            var _sender = sender as CheckBox;
            _sender.Tag = "";
            var border = _sender.Parent as Border;
            border.Child = null;
            testStack.Children.Remove(border);
            testStack.Children.Insert(0,_sender);
        }
        private void eins_Checked(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer()
            { 
               Interval = new TimeSpan(0,0,1) 
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (eins.IsChecked == true)
            { 
                //do whatever you want to do
            }
        }
