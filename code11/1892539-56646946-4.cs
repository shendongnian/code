    public async Task DoRun()
    {
        try
        {
            var x=await longOperation();
            var num=await anotherLongOperation(x);
            if(num<0)
            {
                return;
            }
            textBox.Text=String.Format("The result is {0}",num);
        }
        catch(Exception exc)
       {
          //Do something about it
       }
    }
