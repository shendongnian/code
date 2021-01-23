    string line;
    var file = new System.IO.StreamReader("C:\\PATH_TO_FILE\\test.txt");
    while ((line = file.ReadLine()) != null)
    {
        listBox1.Items.Add(line);
    }
