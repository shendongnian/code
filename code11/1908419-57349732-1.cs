    if(openText.ShowDialog() == DialogResult.OK)
    {
        // If you want to pass the file content, you read it 
        string fileData = File.ReadAllText(openText.FileName);
        Form2 newText = new Form2();
        newText.MdiParent = this;
        // and pass the content to the set accessor for TextFilename.
        newText.TextFileName = fileData;
        // Of course, if you need to just pass the filename then it is even simpler
        newText.TextFileName = openText.FileName;
        newText.Show();
    }
