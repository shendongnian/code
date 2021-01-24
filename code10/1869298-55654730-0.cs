      public Collection<PSObject> Invoke(string Query)
        {
            Collection<PSObject> ps = new Collection<PSObject>();
            try
            {
                using (PowerShell PSI = PowerShell.Create())
                {
                    PSI.AddScript(Query);
                    ps = PSI.Invoke();
                }
            }
            catch (Exception ex)
            {
                ps = null;
                throw;
            }
            return ps;
          
        }
