    StreamReader ar = new StreamReader(@"C:\Users\arash\Desktop\problem1 (3).in");
    // Prepare the first line.
    string line = ar.ReadLine();
    while (line != null) {
        // http://msdn.microsoft.com/en-us/library/1bwe3zdy.aspx
        string[] spl = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        MessageBox.Show(spl[0]);
        // Prepare the next line.
        line = ar.ReadLine();
    }
