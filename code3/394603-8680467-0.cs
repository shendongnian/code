    string inputFilename = textBox1.Text;
    string outputFilename = inputFilename.Replace(".", "_new.");
    string regexPattern = textBox2.Text;
    string replaceText = textBox3.Text;
    using (StreamWriter sw = new StreamWriter(outputFilename)))
    {
        foreach (string line in File.ReadAllLines(inputFilename))
        {
            string newLine = Regex.Replace(line, regexPattern, replaceText);
            sw.WriteLine(newLine);
        }
    }
