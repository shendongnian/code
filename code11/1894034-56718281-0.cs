    string[] filePaths = Directory.GetFiles(@"C:\Client\TestFolder\", "*.txt", SearchOption.TopDirectoryOnly);
        listBox1.Items.AddRange(filePaths);
        string[] titleArray = new string[listBox1.Items.Count];
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            titleArray[i] = listBox1.Items[i].ToString();
        }
        Array.Sort(titleArray);
        listBox1.Items.Clear();
        for (int i = 0; i < titleArray.Length; i++)
        {
            listBox1.Items.Add(Path.GetFileNameWithoutExtension(titleArray[i].ToString()));
        }
