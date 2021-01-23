    // Remember to also add a using System.Diagnostics at the top of the class
    private void RunIt_Click(object sender, EventArgs e)
    {
        using (Process p = new Process())
        {
            p.StartInfo.WorkingDirectory = "<path to batch file folder>";
            p.StartInfo.FileName = "<path to batch file itself>";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            p.WaitForExit();
    
            // Capture output from batch file written to stdout and put in the 
            // RunResults textbox
            string output = p.StandardOutput.ReadToEnd();
            if (!String.IsNullOrWhiteSpace(output))
            {
                this.RunResults.Text = output;
            }
    
            // Capture any errors written to stderr and put in the errors textbox.
            string errors = p.StandardError.ReadToEnd();
            if (!String.IsNullOrWhiteSpace(errors))
            {
                this.Errors.Text = errors;
            }
        }
    }
