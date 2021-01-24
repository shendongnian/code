    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            await b();
        }
        catch (Exception E)
        {
            MessageBox.Show($"Exception Handled: \"{E.Message}\"");
        }
    }
    
    async Task b()
    {
        await Task.Run(()=>
        {
            DateTime begin = DateTime.Now;
            while (DateTime.Now.Subtract(begin).TotalSeconds < 3) //Wait 3 seconds
            { /*Do Nothing*/ }
        });
        c();
    }
    void c()
    {
        throw new Exception("Try to handle this exception.");
    }
