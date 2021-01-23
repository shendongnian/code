    StreamReader ar = new StreamReader(@"C:\Users\arash\Desktop\problem1 (3).in");
    string s = ar.ReadLine();
    while (s != null)
    {
        string[] spl = s.Split(' ');
        MessageBox.Show(spl[0]);
        s = ar.ReadLine();
     }
