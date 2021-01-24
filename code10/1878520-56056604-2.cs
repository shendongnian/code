    private async void button2_Click(object sender, EventArgs e)
    {
        Console.WriteLine("STUFF Before");
        await MyAsyncMethod();
        Console.WriteLine("STUFF @ the END");
    }
    public async Task MyAsyncMethod()
    {
        //Action 1	
        Console.WriteLine("Action 1 ");
        await Task.Delay(1000);
        //Action 2	
        Console.WriteLine("Action 2 ");
        await Task.Delay(1000);
        //Action 3	
        Console.WriteLine("Action 3 ");
        await Task.Delay(1000);
    }
