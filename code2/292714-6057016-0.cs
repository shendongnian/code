    private void timer1_Tick(object sender, EventArgs e)
    { 
        Console.WriteLine(DateTime.Now.ToString());
        Task.Factory.StartNew(() => CalculationMethod());
    }
