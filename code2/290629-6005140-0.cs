    private void runSyncAndGetResults_Click(object sender, System.EventArgs e)     
    {
        System.Diagnostics.ProcessStartInfo psi =
           new System.Diagnostics.ProcessStartInfo(@"C:\batch.bat");
 
        psi.RedirectStandardOutput = true;
        psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        psi.UseShellExecute = false;
  
        System.Diagnostics.Process batchProcess;
        batchProcess = System.Diagnostics.Process.Start(psi);
    
        System.IO.StreamReader myOutput = batchProcess.StandardOutput;
        batchProcess.WaitForExit(2000);
        if (batchProcess.HasExited)
        {
            string output = myOutput.ReadToEnd();
            // Print 'output' string to UI-control
        }
    }
