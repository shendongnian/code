    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
             (e.KeyChar !='.'))
            { 
              e.Handled = true;
              MessageBox.Show("Only Alphabets");
            }
        }
 
