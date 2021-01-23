    StreamReader ar = new StreamReader(@"C:\Users\arash\Desktop\problem1 (3).in");
    // Prepare the first line.
    string line = ar.ReadLine();
    while (line != null) {
        string[] spl = line.Split(' ');
        MessageBox.Show(spl[0]);
        // Prepare the next line.
        line = ar.ReadLine();
    }
