    System.IO.StreamReader file = new System.IO.StreamReader(filePath);
    string data = file.ReadToEnd();
    file.Close();
    data = Regex.Replace(data, "<.*\n", "");
    System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, false);
    file.Write(data);
    file.Close();
