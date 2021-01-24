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
            
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            Dispose();
        }
  [1]: http://www.blackwasp.co.uk/CaptureProcessOutput.aspx
