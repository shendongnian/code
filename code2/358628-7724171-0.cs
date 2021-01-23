    private void button3_Click(object sender, EventArgs e)
        {
            string filename = "";
            string FolderPath;
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = openFileDialog2.FileName;
                FolderPath = Path.GetDirectoryName(filename);
                textBox3.Text = filename;
                System.IO.StreamReader file2 = new System.IO.StreamReader(textBox3.Text); 
            }
        }
    private void button2_Click(object sender, EventArgs e)
        {
            if (Path.GetExtension(colB[j]) == ".csv")
                textBox2.Text += " comma separated, in line " + j + "" + Environment.NewLine;
        }
