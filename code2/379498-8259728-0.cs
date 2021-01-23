        // put the lines in an array
        string[] result = textBox1.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder output = new StringBuilder();
        foreach (string line in result)
        {
            output.AppendLine(WorkingSolutionForOneLine(line));
        }
        string finalResult = output.ToString();
