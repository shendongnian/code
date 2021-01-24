    private void textBox1_TextChanged(object sender, EventArgs e) {
      textBox2.TextChange -= textBox2_TextChanged;
      try {
        textBox2.Text = Convert(textBox1.Text); 
      }
      finally {
        textBox2.TextChange += textBox2_TextChanged;
      }
    }
    private void textBox2_TextChanged(object sender, EventArgs e) {
      textBox1.TextChange -= textBox1_TextChanged;
      try {
        textBox1.Text = ReverseConvert(textBox2.Text); 
      }
      finally {
        textBox1.TextChange += textBox1_TextChanged;
      }
    }
