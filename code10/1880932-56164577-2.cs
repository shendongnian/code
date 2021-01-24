      public C2(List<int> lNumbers) {
        lNumbers.Sort();
        try
        {
            Series.Clear();
            Series.Add(new C1(lNumbers[0])));
            Series.Add(new C1(lNumbers[1]));
            Series.Add(new C1(lNumbers[2]));
            Series.Add(new C1(lNumbers[3]));
            Series.Add(new C1(lNumbers[4]));
            Series.Add(new C1(lNumbers[5]));
        }
        catch (OverflowException)
        {
            MessageBox.Show("M1!","M2");
            throw;
        }
    }
