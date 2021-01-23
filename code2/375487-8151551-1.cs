    StringBuilder output = new StringBuilder();
    using (StreamReader sr = new StreamReader(filename))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("</head>"))
            {
                line = "<img src=\"result_files\\image003.png\"/>" + line;
            }
                    output.AppendLine(line);
        }
    }
    using (StreamWriter writer = new StreamWriter(filename, false, encoding))
    {
        writer.Write(output.ToString());
    }
