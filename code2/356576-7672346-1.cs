    private void button1_Click_1(object sender, EventArgs e)
    {
        List<String> Lines = new List<String>();
        try 
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    while ((data = sr.ReadLine()) != null)
                    {
                        Lines.Add(data);
                    }
                }
                FilePath.Text = openFileDialog1.FileName;
            }
        }
        catch(IOException ex) 
        {
            MessageBox.Show("there is an error" + ex+ "in the file please try again");
        }
    }
