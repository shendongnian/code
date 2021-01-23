        string path = @"C:\Users\dave\Desktop\codes\testfile.txt";
        StreamReader sr = new StreamReader(path);
        List<string> stkno = new List<string>();
        string s;
        while(s = sr.ReadLine() != null)
        {
            string[] words = s.Split(',');
            stkno.Add(words[1]);
        }
        var message = string.Join(",", stkno.ToArray());
        MessageBox.Show(message);
