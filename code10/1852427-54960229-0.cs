	private void Form1_Load(object sender, EventArgs e)
	{
		tbKeywords.Text = "auto, work, the";
		textBox1.Text = "Today the auto industry is booming. Automated machines are big part of it and it's working great. They are doing very big autonomous work.";
	}
	private void button1_Click(object sender, EventArgs e)
	{
		textBox2.Text = AddSpaceAroundWords(textBox1.Text, tbKeywords.Text);        
	}
	private string AddSpaceAroundWords(string sentence, string CommaSeparatedKeyWords)
	{
		int index;
		string keyword;
		foreach (string key in CommaSeparatedKeyWords.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
		{
			index = 0;
			keyword = key.Trim();       
			while ((index = sentence.IndexOf(keyword, index, StringComparison.InvariantCultureIgnoreCase)) != -1)
			{
				if ((index > 0) && (sentence[index - 1] != ' '))
				{
					sentence = sentence.Insert(index++, " ");
				}
				if (((index + keyword.Length) < sentence.Length) && (sentence[index + keyword.Length] != ' ')) {
					sentence = sentence.Insert(index++ + keyword.Length, " ");
				}
				index += keyword.Length;
			}
		}
		return sentence;
	}
