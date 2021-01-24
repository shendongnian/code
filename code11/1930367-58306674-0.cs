csharp
public int getLines(string comment)
{
	int height_ln = 0;
	string[] lines;
	
	//split into lines based on linebreaks
	if (comment.Contains("\n"))
	{
		lines = comment.Split('\n');
	}
	else
	{
		lines = new string[1];
		lines[0] = comment;
	}
	
	//check each line to see if it'll receive automatic linebreaks
	foreach(string line in lines)
	{
		int text_width = TextRenderer.MeasureText(line, rtbKommentar.Font).Width;
		double text_lines_raw = (double)text_width / 1400; //1400 is the width of my RichTextBox
		int text_lines = 0;
		if (line.Contains("\r")) //Please don't call me out on this, I'm already feeling dirty
			text_lines = (int)Math.Floor(text_lines_raw);
		else
			text_lines = (int)Math.Ceiling(text_lines_raw);
		if (text_lines == 0)
			text_lines++;
		height_ln += text_lines;
	}
	return height_ln; //this is the number of lines required, to adjust the height of the RichTextBox I need to multiply it by 15, which is the font's height.
}
