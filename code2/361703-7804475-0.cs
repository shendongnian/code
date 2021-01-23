    List<string> lines = new List<string>();
    lines.Add("<html>");
    lines.Add("<body>");
    lines.Add("Hello World");
    lines.Add("</body>");
    lines.Add("</html>");
    File.WriteAllText("myfile.htm", lines);
    // With C# 3.5
    File.WriteAllText("myfile.htm", lines.ToArray());
