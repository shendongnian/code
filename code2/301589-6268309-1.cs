    public void Function()
    {
         if (this.InvokeRequired)
         {
             this.BeginInvoke(new Action(this.Function));
             return;
         }
         // controller.DoSomething();         
    }
