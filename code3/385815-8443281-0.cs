    string input = "C:\Projects\test\whatever\files\media\10\00\00\80\test.jpg";
    string[] parts = toSplit.Split(new char[] {'\\'});
    IEnumerable<string> reversed = parts.Reverse();
    IEnumerable<string> selected = reversed.Skip(1).Take(4).Reverse();
    string result = string.Concat(selected);
