        public async Task<bool> Runcmd()
        {
            ProcessResults results = await ProcessEx.RunAsync(
                "PortQry.exe",
                 command
            );
            if(results.StandardOutput.Any(output => output.Contains(resolve_pass)))
               return true;
            return false;
        }
