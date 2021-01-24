    private async void btnExec_Click(object sender, EventArgs e)
    {
        try
        {
           await Task.Run(() => LongProcess());
           // or
           await Task.Run(LongProcess);
        }
        catch (Exception exception)
        {
           // catch any exceptions, as this method will be unobserved 
           // Console.WriteLine(exception);
        }
    }
