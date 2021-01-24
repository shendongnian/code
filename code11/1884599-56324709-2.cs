    // progressBar1.Value = 0;
    // progressBar1.Minimum = 0;
    // progressBar1.Maximum = 100; 
    
    private void Timer1_Tick(object sender, EventArgs e)
    {
        this.progressBar1.Increment(1);
        if(progressBar1.Value == progressBar1.Maximum){
            Process.Start("c:\\file.bat");
        }
    }
