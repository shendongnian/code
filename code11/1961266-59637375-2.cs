    public void button1_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
        textBox1.Text = openFileDialog1.FileName;
        string[] lines = System.IO.File.ReadAllLines(textBox1.Text);
        string firstline = lines[0];
        string[] headerLabels = firstline.Split(',');
        foreach (string headerWord in headerLabels)
        {
            DataGridViewComboBoxColumn dgv = new DataGridViewComboBoxColumn
            {
                ReadOnly = false,
                Name = headerWord,
                DataSource = new string[] { "YES", "NO" }
            };
            dataGridView1.Columns.Add(dgv);
        }
    }
