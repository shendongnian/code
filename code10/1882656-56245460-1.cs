C#
        void ThreadMain()
        {
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            
            while( true ) 
            { 
                // ...
                Thread.Sleep( 250 ); 
            } 
            
            process.CancelOutputRead();
            process.CancelErrorRead();
            Dispose();
        }
  [1]: http://www.blackwasp.co.uk/CaptureProcessOutput.aspx
