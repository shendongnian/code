    public class ListPreference
    {
        Popup p;
        string Name;
        int oldValue;
        public delegate void DismissedHandler(string name, bool changed, int newvalue);
        public event DismissedHandler Dismissed;
        public bool IsOpen
        {
            get
            {
                return p.IsOpen;
            }
            set
            {
                p.IsOpen = value;
            }
        }
        public ListPreference(string name, Array elements, int default_value)
        {
            p = new Popup();
            Name = name;
            Dismissed = null;
            oldValue = default_value;
            double height = (App.Current.RootVisual as FrameworkElement).ActualHeight;
            double width = (App.Current.RootVisual as FrameworkElement).ActualWidth;
            p.VerticalOffset = SystemTray.IsVisible ? 32.0 : 0.0;
            p.Height = height;
            p.Width = width;
            Canvas canvas = new Canvas();
            SolidColorBrush colorBrush = new SolidColorBrush(Colors.Black);
            colorBrush.Opacity = 0.75;
            //Color.FromArgb(0xff, 0x8a, 0x8a, 0x8a));
            canvas.Background = colorBrush;
            //canvas.Opacity = 0.765;
            canvas.Height = height;
            canvas.Width = width;
            p.Child = canvas;
            Border border = new Border();
            border.Width = width - 50.0 * 2.0;
            border.BorderBrush = new SolidColorBrush(Colors.LightGray);
            border.BorderThickness = new Thickness(5.0);
            border.Background = new SolidColorBrush(Colors.Black);
            canvas.Children.Add(border);
            StackPanel panel2 = new StackPanel();
            panel2.Orientation = System.Windows.Controls.Orientation.Vertical;
            int i = 0;
            foreach (string val in elements)
            {
                RadioButton radio1 = new RadioButton();
                radio1.GroupName = "group1";
                radio1.Content = val;
                if (i == default_value)
                    radio1.IsChecked = true;
                int j = i;
                radio1.Click += (sender, args) => radio1_Checked(radio1, j);
                i++;
                panel2.Children.Add(radio1);
            }
            Button button1 = new Button();
            button1.Background = new SolidColorBrush(Colors.Black);
            button1.Foreground = new SolidColorBrush(Colors.White);
            button1.Opacity = 1.0;
            button1.Content = "Cancel";
            button1.Margin = new Thickness(5.0);
            button1.Click += new RoutedEventHandler(closeButton_Click);
            panel2.Children.Add(button1);
            border.Child = panel2;
            // Open the popup.
            p.IsOpen = true;
            p.UpdateLayout();
            border.Height = panel2.DesiredSize.Height + 5.0 * 2.0;
            border.SetValue(Canvas.TopProperty, (height - border.Height) / 2.0);
            border.SetValue(Canvas.LeftProperty, (width - border.Width) / 2.0);
            p.UpdateLayout();
        }
        void closeButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the popup.
            p.IsOpen = false;
            if (Dismissed != null)
            {
                Dismissed(Name, false, -1);
            }
        }
        void radio1_Checked(object sender, int idx)
        {
            RadioButton b = sender as RadioButton;
            string val = b.Content as string;
            p.IsOpen = false;
            if (Dismissed != null)
            {
                Dismissed(Name, idx != oldValue, idx);
            }
        }
    }
