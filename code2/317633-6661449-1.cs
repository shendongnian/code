    using System.IO;
    XDocument root = XDocument.Parse(File.ReadAllText(file),
                                  LoadOptions.PreserveWhitespace); 
    string content = (from Content in root.Descendants("content")
                       select (string)Content.Value).Single();
    File.WriteAllText("SomeTempFile.txt", content);
