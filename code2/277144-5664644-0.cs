    var input = new FileStream(inputFilename, FileMode.Open);
    var output = new FileStream(outputFilename, FileMode.Create);
    var reader = new StreamReader(input);
    var writer = new BinaryWriter(output);
    var data = reader.ReadLine();
    var maxSize = 10000;
    var totalLength = 0;
    while (!string.IsNullOrWhitespace(data) && totalLength < maxSize)
    {
      var bytes = System.Text.UnicodeEncoding.GetBytes(data);
      totalLength += bytes.GetLength(0);
      if totalLength < maxSize) writer.Write(bytes);
      data = reader.ReadLine();
    }
    writer.Flush();
    writer.Close();
    reader.Close();
