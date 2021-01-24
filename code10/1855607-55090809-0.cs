     private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex!=-1)
            {
                FileInfo selectedFile = files[listBox1.SelectedIndex];
                ScriptBox.Text = File.ReadAllText(selectedFile.FullName);
            }
        }
