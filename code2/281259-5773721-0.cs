                var startInfo = new ProcessStartInfo( executable, parameters )
                {
                    UseShellExecute = false,
                    RedirectStandardError = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = true
                };
    
                using( var process = Process.Start( startInfo ) )
                {
                    if( process != null )
                    {
                        process.WaitForExit( timeoutInMilliSeconds );
                        return process.ExitCode;
                    }
                }
