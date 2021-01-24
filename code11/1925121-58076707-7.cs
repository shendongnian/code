    private void textBox1_TextChanged(object sender, EventArgs e) {
      textBox2.TextChange -= textBox2_TextChanged;
      try {
        // Since textBox2.TextChanged switched off,
        // changing textBox2.Text will not cause textBox1.Text change
        textBox2.Text = Convert(textBox1.Text); 
      }
      finally {
        textBox2.TextChange += textBox2_TextChanged;
      }
    }
    private void textBox2_TextChanged(object sender, EventArgs e) {
      textBox1.TextChange -= textBox1_TextChanged;
      try {
        // Since textBox1.TextChanged switched off,
        // changing textBox1.Text will not cause textBox2.Text change
        textBox1.Text = ReverseConvert(textBox2.Text); 
      }
      finally {
        textBox1.TextChange += textBox1_TextChanged;
      }
    }
