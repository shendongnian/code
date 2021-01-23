       private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text.Length == 10)
                button1.IsEnabled = true;
            else
                button1.IsEnabled = false;
        }
