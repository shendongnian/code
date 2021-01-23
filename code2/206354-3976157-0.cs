    for(string line in text)
    {
        int index = line.LastIndexOf("Stuff");
        if(index != -1)
        {
            listBox1.Items.Add(line.Substring(index));
        }
    }
