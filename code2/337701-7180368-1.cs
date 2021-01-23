    TextReader streamReader = new StreamReader("c:\\test.txt");
    string input = streamReader.ReadLine();
    string[] chars = input.Split(new char[] { '\\', 'u' }, 
        StringSplitOptions.RemoveEmptyEntries);
    streamReader.Close();
    string answer = string.Empty;
    foreach (string charachter in chars)
    {
        byte byte1 = byte.Parse(string.Format("{0}{1}", 
            charachter[0], charachter[1]), NumberStyles.AllowHexSpecifier);
        byte byte2 = byte.Parse(string.Format("{0}{1}", 
            charachter[2], charachter[3]), NumberStyles.AllowHexSpecifier);
        answer += Encoding.Unicode.GetString(new byte[] { byte2, byte1 });
    }
