    MyUserControl uc = null;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (!(uc == null || uc.IsDisposed || uc.Disposing))
        {
            this.Controls.Remove(uc);
            uc.Dispose();
        }
        uc = new MyUserControl();
        this.Controls.Add(uc);
        uc.OKSelected += (obj, args) => { timer1.Stop(); };
        uc.ProcessingFinished += (obj, args) =>
        {
            MessageBox.Show(uc.Info);
            timer1.Start();
        };
    }
