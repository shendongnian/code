    TextBox textDescription = new TextBox();
    private void button1_Click(object sender, EventArgs e)
    {
        this.Controls.Add(textDescription);
        textDescription.Location = new Point(180, 190);
        textDescription.Size = new Size(154, 20);
        textDescription.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        textDescription.Text = "123";
    }
    private void button2_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows[0].Cells[0].Value = textDescription.Text;
    }
