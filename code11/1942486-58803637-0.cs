    using (var reader = new StreamReader(@"yourfile"))
    using (var writer = new StreamWriter(@"outfile")) // or any other TextWriter
    {
        while (!reader.EndOfStream) {
            string currentLine = reader.ReadLine();
            string newLine = currentLine.Replace('\r\n','\n');
            newLine = newLine.Replace('\r','\n');
            newLine = newLine.Replace('\n','\r\n');
            writer.Write(newLine);
        }
    }
