    private async void BThr4_Click(object sender, EventArgs e)
    {
        Clear();
        DateTime start = DateTime.Now;
        await Task.Delay(100);
        Task<Sample> t1 = Task<Sample>.Run(() => CalculateStuff(PBar1, max / 4));
        Task<Sample> t2 = Task<Sample>.Run(() => CalculateStuff(PBar2, max / 4));
        Task<Sample> t3 = Task<Sample>.Run(() => CalculateStuff(PBar3, max / 4));
        Task<Sample> t4 = Task<Sample>.Run(() => CalculateStuff(PBar4, max / 4));
        
        Sample sample1 = await t1;
        Sample sample2 = await t2;
        Sample sample3 = await t3;
        Sample sample4 = await t4;
        TextBox.Text = (DateTime.Now - start).ToString(@"hh\:mm\:ss");
        t1.Dispose(); t2.Dispose(); t3.Dispose(); t4.Dispose();
    }
    // Calculate some math stuff
    private static Sample CalculateStuff(ProgressBar pb, ulong max)
    {
        Sample s = new Sample();
        ulong c = max / (ulong)pb.Maximum;
        for (ulong i = 1; i <= max; i++)
        {
            s.A = Math.Pow(s.A, 1.2);
            if (i % c == 0)
                pb.Invoke(new Action(() => pb.Value = (int)(i / c)));
        }
        return s;
    }
