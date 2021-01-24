    private void IncrementBy1(object sender, RoutedEventArgs e)
        {
            // code for incrementing the textbox by 1
            Button btn = sender as Button;
            var parent = VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(btn));
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var textBox = VisualTreeHelper.GetChild(parent, i) as TextBox;
                if (textBox != null)
                {
                    var value = int.Parse(textBox.Text);
                    textBox.Text = (++value).ToString();
                    break;
                }
            }
        }
