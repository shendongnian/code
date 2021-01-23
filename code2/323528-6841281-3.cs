        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var message = context.Evaluate(textBox1.Text);
            if (message != null) MessageBox.Show(message); // display result
        }
