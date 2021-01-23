    String line;
    String path = "c:/sample.txt";
    using (StreamReader sr = new StreamReader(path))
	{
	    while ((List<string> lines = ReadGroup(sr)) != null)
		{
			// you might want to check for lines.Count >= 4 if you will
			// have groups with fewer lines to provide a better error
			//display the readed lines in the text box
	        disTextBox.AppendText(string.Format("{0}\t{1}\t{2}{3}",
				lines[0], lines[2], lines[3], Environment.NewLine);
	    }
		sr.Close();
	}
