    private void lblWrn_TextChange(object sender, EventArgs e)
    {
        var Timee = new System.Timers.Timer(5000);
        Timee.Elapsed += this.timerClearWrn;
        Timee.AutoReset = false; // Raise the Elapsed event only once
        Timee.Enabled = true;
    }
    private void timerClearWrn(object sender, ElapsedEventArgs elapsed)
    {
        lblWrn.Invoke(
          (MethodInvoker)(()=>
          {
            lblWrn.Text = "";
          }), null);
        var Timee = (System.Timers.Timer)sender;
        Timee.Elapsed -= this.timerClearWrn;
    }
