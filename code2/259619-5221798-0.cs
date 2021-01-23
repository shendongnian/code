    private void button2_Click(object sender, System.EventArgs e) {
        using (Form2 xForm = new Form2()) {
            if (xForm.ShowDialog(this) == DialogResult.OK) {
                // Take some action
    
            }
        }
    }
