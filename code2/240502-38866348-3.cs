    private void timer1_Tick(object sender, EventArgs e)
    {
     int cnt = progressBar1.Value;
   
        switch (cnt)
        {
            case 0:
                    //Do sum stuff
                break;
            case 100:
                this.Close(); //close the frm-splash
                frmMain.ActiveForm.Opacity = 100; // show the frm-main
                break;
        }
        
        progressBar1.Value = progressBar1.Value+1;
    }
