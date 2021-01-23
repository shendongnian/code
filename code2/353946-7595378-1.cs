    StreamReader ar = new StreamReader(@"C:\Users\arash\Desktop\problem1 (3).in");
    string s = ar.ReadLine();
    while (s != null)
    {
        //string[] spl = s.Split(' ');
        // below code seems safer, blatantly copied from one of the other answers..
        string[] spl = s.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        MessageBox.Show(spl[0]);
        s = ar.ReadLine();
     }
