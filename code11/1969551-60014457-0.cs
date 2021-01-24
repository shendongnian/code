    private async void BtnRunClick(object sender, EventArgs e)
    {
        int nlines = 0;
        while(nlines < 50) {
            nlines = listBox1.Items.Count;
            await ReadLinesFromFile();
            await Task.Delay(1000);
        }
    }   
    private async Task ReadLinesFromFile()
    {
        var file = @"D:\Temp1\testfile.txt";
        string[] lines = await ReadFrom(file);
        listBox1.Items.Clear();
        foreach(string line in lines) {
            listBox1.Items.Add(line);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
    }
    private async Task<string[]> ReadFrom(string file)
    {
        using (var reader = File.OpenText(file))
        {
            var content = await reader.ReadToEndAsync();
            return content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
