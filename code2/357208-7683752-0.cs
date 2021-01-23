    public void button2_Click(object sender, EventArgs e)
    {
        string file_name = textBox1.Text.ToString();
        // Get the directories to split the file in.
        string directoryPath = Path.GetDirectoryName(textBox1.Text.ToString());
        if (File.Exists(file_name) == true)
        {
            try
            {
                using (StreamReader reader= new StreamReader(file_name))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Do your stuff
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                string message2 = "Cannot write to source destination";
                MessageBox.Show(message2, "Error");
            }
        }
        else
        {
            MessageBox.Show("No such file exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
