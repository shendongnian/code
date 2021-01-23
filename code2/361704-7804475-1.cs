    List<string> lines = new List<string>();
    lines.Add("<html>");
    lines.Add("<body>");
    lines.Add("Hello World");
    lines.Add("</body>");
    lines.Add("</html>");
    File.WriteAllLines("myfile.htm", lines);
    // With C# 3.5
    File.WriteAllLines("myfile.htm", lines.ToArray());
