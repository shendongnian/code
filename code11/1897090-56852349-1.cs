    private async void button1_Click(object sender, EventArgs e)
    {
        void DoSomeWork(IProgress<(string Message, int Progress)> progress = null)
        {
            var loops = 5;
            for (var i = 0; i < loops; ++i)
            {
                progress?.Report(($"Loop {i + 1}", (i + 1) * 100 / loops));
                Thread.Sleep(500);
            }
            throw new DivideByZeroException("...");
        }
        try
        {
            await ProgressForm.ShowAsync(this, DoSomeWork);
        }
        catch (DivideByZeroException)
        {
            MessageBox.Show("Yeah...");
        }
    }
