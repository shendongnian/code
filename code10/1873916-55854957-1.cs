    List<string> fileNames = null;
    List<string> fileExtensions = null;
    private void btn_list_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog fbd = new FolderBrowserDialog())
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                lbl_path.Text = fbd.SelectedPath;
                fileNames = Directory.GetFiles(fbd.SelectedPath).ToList();
                fileExtensions = fileNames.Select(item => 
                    Path.GetExtension(item).Replace(".", "")).Distinct().OrderBy(n => n).ToList();
                listBox_name..DataSource = fileNames.Select(f => Path.GetFileName(f)).ToList();
                listBox_ex.DataSource = fileExtensions;
            }
        }
    }
    private void btn_CreateFolder_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog fbd = new FolderBrowserDialog())
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                lbl_pathCreated.Text = fbd.SelectedPath;
                fileExtensions.ForEach(item => 
                    Directory.CreateDirectory(Path.Combine(fbd.SelectedPath, item)));
            }
        }
    }
