    string input =Yourinputstring;
    string[] strings = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string value in strings)
    {
       string newv= value.Trim();
       if (newv.Length > 0)
       newline += value + "\r\n";
    }
