    Add Sql server exe in the deployment project.
    Add the commit event in this class like below.
    public override void Commit(IDictionary savedState)
            {
                try
                {
                    base.Commit(savedState);
                    Process p = System.Diagnostics.Process.Start("Your path of sql server exe");
                    if (!p.HasExited)
                    {
                        p.Refresh();
                    }
                    while (!p.WaitForExit(1000)) ;
                    
                }
                catch (Exception)
                {
                    throw new InstallException();
                }
                finally
                {
                    startuppath = null;
                }
            }
