    private void button1_Click(object sender, EventArgs e)
    {
        using (var dialog = new OpenFileDialog())
        {
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            pictureBox1.Image = Image.FromFile(dialog.FileName);
        }
    }
