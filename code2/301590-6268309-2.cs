    public void Function2(int someValue)
    {
         if (this.InvokeRequired)
         {
             this.BeginInvoke(new Action(() => this.Function2(someValue)));
             return;
         }
         // controller.DoSomething(someValue);         
    }
