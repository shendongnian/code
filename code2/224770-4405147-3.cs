    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Phone.Controls;
    
    namespace WindowsPhoneApplication2 {
        public partial class MainPage : PhoneApplicationPage {
            // Constructor
            public MainPage() {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e) {
                int numBoxes = Int32.Parse(((Button) sender).Content.ToString());
                DynamicPanel.Children.Clear();
                for (int i = 0; i < numBoxes; i++) {
                    var newTextBlock = new TextBlock { Name = "textBlock" + i.ToString(), Text = "Hello!" };
                    DynamicPanel.Children.Add(newTextBlock);
                }
            }
        }
    }
