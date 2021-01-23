     private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
             
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
