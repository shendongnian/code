    ConcurrentDictionary<string, StreamWriter> writers = new ConcurrentDictionary<string, StreamWriter>();
    string[] fileContent = File.ReadAllLines("MAIN_FILE_PATH");
    var Tasks = System.Threading.Tasks.Parallel.For(0, fileContent.Length, (i) =>
    {
      string MyFile = ((int)(i / 100f)).ToString("0000") + ".txt";
      writers.GetOrAdd(MyFile, File.AppendText(MyFile)).WriteLine(fileContent[i]);
    });
    foreach (var writer in writers)
      writer.Value.Close();
