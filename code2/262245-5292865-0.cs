using (var streamOut = new StreamWriter(outputFileName)
{
  using (var streamIn = new StreamReader(inputFileName)
  {
     while (!streamIn.EndOfStream)
     {
        string line = streamIn.ReadLine();
        line = line.Replace("AddNewLine", "\n\r\n");
        streamOut.WriteLine(line);
     }
  }
}
