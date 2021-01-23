    tbxAnswer.KeyUp += new KeyEventHandler(tbxAnswer_KeyUp);
    private void tbxAnswer_TextChanged(object sender, EventArgs e)
        {
           
        }
    
        private void tbxAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
    
                MessageBox.Show("Hello");
    
            }
        }
