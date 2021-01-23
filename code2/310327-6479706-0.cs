    string[] lines = System.IO.File.ReadAllLines(@"ignore.txt");
    
    foreach (string line in lines)
    {
        listBox.Items.Add(line);
    }
