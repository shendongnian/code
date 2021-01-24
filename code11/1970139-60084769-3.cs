    private async void button1_Click(object sender, EventArgs e)
    {
        //With this solution, exceptions are treated inside b's body
        //and it will not rethrow the exception, so encapsulating the call to b()
        //in a try-catch block is redundant and unecessary, since it will never
        //throw an exception to be caught in the level of the call stack.
        await Task.Run(() => { b(); });
    }
    
    void b()
    {
        DateTime begin = DateTime.Now;
        while (DateTime.Now.Subtract(begin).TotalSeconds < 3) //Wait 3 seconds
        { /*Do Nothing*/ }
        try
        {
            c();
        }
        catch (Exception)
        {
            //Log the error here.
            //DO NOT re-throw the exception.
        }
    }
    void c()
    {
        throw new Exception("Try to handle this exception.");
    }
