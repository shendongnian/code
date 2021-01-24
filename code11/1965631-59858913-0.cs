        public void RunCommand()
        {
            var processStartInfo = new ProcessStartInfo(
                "notepad.exe")
            {
                UseShellExecute = true,
                Verb = "Runas",
            };
            var process = Process.Start(processStartInfo);
            process.WaitForExit(1000);
        }
        catch (Win32Exception e)
        {
            if (e.ErrorCode == 1223 || e.ErrorCode == -2147467259)
                // Throw easily recognizable custom exception.
                throw new ElevatedPermissionsDeniedException("Unable to get elevated privileges", e);
            else
                throw;
        }
