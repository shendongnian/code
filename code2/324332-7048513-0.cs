       using ( var proc = new Process() )
        {
            proc.StartInfo = new ProcessStartInfo( "cscript" );
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.OutputDataReceived += new DataReceivedEventHandler( proc_OutputDataReceived );
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            proc.OutputDataReceived -= new DataReceivedEventHandler( proc_OutputDataReceived );
        }
    void proc_OutputDataReceived( object sender, DataReceivedEventArgs e )
    {
        var line = e.Data;
        if ( !String.IsNullOrEmpty( line ) )
        {
            //TODO: at this point, the variable "line" contains the progress
            // text from your script. So you can do whatever you want with
            // this text, such as displaying it in a label control on your form, or
            // convert the text to an integer that represents a percentage complete
            // and set the progress bar value to that number.
        }
    }
