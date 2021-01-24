            StringBuilder sb = new StringBuilder();`
            PowerShell psExec = PowerShell.Create();
            psExec.AddCommand(@"C:\Users\d92495j\Desktop\test.ps1");
            psExec.AddArgument(DateTime.Now);
            Collection<PSObject> results;
            Collection<ErrorRecord> errors;
            results = psExec.Invoke();
            errors = psExec.Streams.Error.ReadAll();
            if (errors.Count > 0)
            {
                foreach (ErrorRecord error in errors)
                {
                    sb.AppendLine(error.ToString());
                }
            }
            else
            {
                foreach (PSObject result in results)
                {
                    sb.AppendLine(result.ToString());
                }
            }
            Console.WriteLine(sb.ToString());
        }
