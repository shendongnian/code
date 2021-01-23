       private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement control in myGrid.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)control;
                    txtBox.Text = null;
                }
            }
        }
