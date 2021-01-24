    System.IO.StreamReader file = new System.IO.StreamReader(path);
    string line;
    string lin2;
    int counter = 0;
    while ((line = file.ReadLine()) != null)
    {
        counter++;
    }
    file.Close();
    System.IO.StreamReader file2 = new System.IO.StreamReader(path);
    string[] file_by_lines = new string[counter+5];
    for(int i =0; i < counter; i++)
    {
        lin2 = file2.ReadLine();
        if (!string.IsNullOrEmpty(lin2))
        {
            file_by_lines[i] = lin2;
        }
    }
    file2.Close();
    string file_by_line = string.Concat(file_by_lines);
    var b = Encoding.GetEncoding(1252).GetBytes(file_by_line);
    string s = Encoding.GetEncoding(1251).GetString(b);
    System.IO.File.WriteAllText(path + "_1251_variant1", s, Encoding.GetEncoding(1251));
