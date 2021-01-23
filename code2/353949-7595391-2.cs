        StreamReader ar = new StreamReader(@"C:\Users\arash\Desktop\problem1 (3).in");
        while ((string line = ar.ReadLine()) != null)
        {
            string[] spl = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            MessageBox.Show(spl[0]);
        }
