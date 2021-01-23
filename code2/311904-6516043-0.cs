    private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (iterator < name.Count)
            {
                txtBox.Text = name[iterator].InnerText;
            }
            iterator++;
        }
