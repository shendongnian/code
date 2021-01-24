    private void Button5_Click(object sender, EventArgs e) {
      if (NameExists(textBox1.Text)) {
        // Let us be nice: put keyboard focus on the problem field
        if (textBox1.CanFocus) {
          textBox1.Focus();
          // textBox1.SelectAll(); // if you want to select all the text
        }
        MessageBox.Show("This name already exists!");
        return; 
      }
      //given name passed validation control (name is all russian letters and unique)
      //TODO: put relevant code here (start the game?)
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e) {
      textBox1.Text = string.Concat(textBox1.Text.Where(c => IsValidNameCharacter(c)));
    }
