    private Pietschsoft.NativeProgressDialog pd;
    private uint progressPercent;
    FileOperation fileOp;
    Timer timer1 = new Timer();
    private void button1_Click_1(object sender, EventArgs e)
    {
        timer1.Interval = 300;
        timer1.Tick += (s,ev)=>
        {
            progressPercent++;
            if (pd.HasUserCancelled)
            {
                timer1.Stop();
                pd.CloseDialog();
            }
            else
            {
                // Update the progress value
                pd.Value = progressPercent;
                pd.Line2 = "Percent " + progressPercent.ToString() + "%";
                if (progressPercent >= 100)
                {
                    timer1.Stop();
                    pd.CloseDialog();
                }
            }
        };
        pd = new Pietschsoft.NativeProgressDialog(this.Handle);
        pd.Title = "Performing Operation";
        pd.CancelMessage = "Please wait while the operation is cancelled";
        pd.Maximum = 100;
        pd.Value = 0;
        pd.Line1 = "Line One";
        pd.Line3 = "Calculating Time Remaining...";
        //pd.ShowDialog(); // Defaults to PROGDLG.Normal
        pd.ShowDialog(Pietschsoft.NativeProgressDialog.PROGDLG.Modal, Pietschsoft.NativeProgressDialog.PROGDLG.AutoTime, Pietschsoft.NativeProgressDialog.PROGDLG.NoMinimize);
        progressPercent = 0;
        timer1.Start();
    }
