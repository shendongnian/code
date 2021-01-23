        StreamReader ar = new StreamReader(@"C:\Users\arash\Desktop\problem1 (3).in");
        string line;
        while ((line = ar.ReadLine()) != null)
        {
            string[] spl = line.Trim().Split(' ');
            MessageBox.Show(spl[0]);
        }
