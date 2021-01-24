     private void TxtFeetInput_TextChanged(object sender, TextChangedEventArgs e)
     {
        if (string.IsNullOrEmpty(txtFeetInput.Text))
        {
           textBox1.Background = Brushes.White;
           return;
        }
        textBox1.Background = double.TryParse(txtFeetInput.Text, out var value) 
                                         && value >= 0? 
                                         Brushes.White : Brushes.Red;
     }
