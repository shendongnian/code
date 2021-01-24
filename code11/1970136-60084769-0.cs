    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            await Task.Run(() => { b(); });
            //also tried:
            //await Task.Run(b);
            //await Task.Run(new Action(b));
        }
        catch (Exception E)
        {
            MessageBox.Show($"Exception Handled: \"{E.Message}\"");
        }
    }
    
    void b()
    {
        DateTime begin = DateTime.Now;
        while (DateTime.Now.Subtract(begin).TotalSeconds < 3) //Wait 3 seconds
        { /*Do Nothing*/ }
        c();
        //c() represents whichever method you're calling inside of b that is throwing the exception.
    }
    void c()
    {
        throw new Exception("Try to handle this exception.");
    }
