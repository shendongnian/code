    private void Button5_Click(object sender, EventArgs e) {
      if (NameExists(textBox1.Text)) {
        // Let us be nice: put keyboard focus on the problem field
        if (textBox1.CanFocus)
          textBox1.Focus();
        MessageBox.Show("This name already exists!");
        return; 
      }
      //TODO: given name passed validation control, put relevant code here
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e) {
      textBox1.Text = string.Concat(textBox1.Text.Where(c => IsValidNameCharacter(c)));
    }
