    richTextBox1.Text = File.ReadAllText(@"New ID.txt").ToString(); 
    
    foreach (string line in richTextBox.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None)
    {
    	listBox1.Items.Add(line); 
    }
