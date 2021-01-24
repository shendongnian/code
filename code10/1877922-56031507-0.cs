    private void button1_Click(object sender, EventArgs e)
    {
        int i = imageList1.Images.Count;
        var ic = new ImageCollection();
        var fbd = new FolderBrowserDialog();
        fbd.Description = "Select meme folder or image.";
        if (fbd.ShowDialog() == DialogResult.OK)
        {
            foreach (var file in Directory.GetFiles(fbd.SelectedPath))
            {
                if (!ic.CheckIfImage(file)) continue;
                imageList1.Images.Add(new Bitmap(file, true));
                listView1.Items.Add($"{Path.GetFileNameWithoutExtension(file)}", i++);
            }
        }
    }
