 c#
Regex regex = new Regex(@"^p\d+");
foreach (string line in textfile)
{    
    if (!regex.IsMatch(line))
    {   
        // get only the lines without starting by pxxx
        newFile.Append(line + "\r\n");
    }
}
Now you append the line, only if it doesn't match the pattern. If it matches you do nothing. It doesn't align with your original code, where you add an empty line, but it aligns with your example.
