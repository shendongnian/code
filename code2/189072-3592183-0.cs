    public class Tool_Button:Button{
            public String tool_name;
            public Tool_Button(String toolname) {
                this.Width = 32;
                this.Height = 32;
                this.BorderBrush = Brushes.Gray;
                tool_name = toolname;
                this.Background = new ImageBrush(new BitmapImage(new Uri(tool_name)));
                this.Click += new RoutedEventHandler(Tool_Button_Click);
            }
    
            void Tool_Button_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show(tool_name);
            }
                
        }
