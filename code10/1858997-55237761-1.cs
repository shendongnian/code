    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    // create list of strings from DTO list
    List<string> items = serviceResponse.dto.NewSoftwareFileDto.Select(x => 
          string.Join(",", x.Property1, x.Property2, ...)).ToList();
    
    // insert newline between every lines (i.e. list indexes)
    string combined = string.Join(Environment.NewLine, items);
    // write combined strings to StreamWriter
    writer.Write(combined);
    writer.Flush();
    stream.Position = 0;
    return File(stream, "text/csv", "filesname.csv");
