    private void button1_Click(object sender, EventArgs e) {
    
            if (textBox1.Text.Equals("admin"))
            {
    
                this.Hide();
    
                // Show another form.
                Form3 f2 = new Form3();
                f2.ShowDialog(this);
            }
        }
