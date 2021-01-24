    private async void Button7_Click(object sender, EventArgs e)
    {
        openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            StreamReader sr = new StreamReader(openFileDialog.FileName);
            var emails =  await sr.ReadToEndAsync();
            foreach (var items in emails)
            {
                aFlistBoxEmail.Items.Add(items);
            }
        }
    }
