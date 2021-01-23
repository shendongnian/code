            // Drop Stored Procs
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\DataContext\\SiteMigrations\\StoredProcs"), "*.sql"))
            {
                // Try to drop proc if its already created
                // Without this, for new procs, seed method fail on trying to delete
                try
                {
                    StreamReader reader = new StreamReader(file);
                    // Read first line of file to create drop command (turning CREATE [dbo].[TheProc] into DROP [dbo].[TheProc])
                    string dropCommand = reader.ReadLine().Replace("CREATE", "DROP");
                    context.Database.ExecuteSqlCommand(dropCommand, new object[0]);
                }
                catch { }
                
            }
            // Add Stored Procs
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\DataContext\\SiteMigrations\\StoredProcs"), "*.sql"))
            {
                // File/Proc names must match method mapping names in DbContext
                int lastSlash = file.LastIndexOf('\\');
                string fileName = file.Substring(lastSlash + 1);
                string procName = fileName.Substring(0, fileName.LastIndexOf('.'));
                
                // First make sure proc mapping in DbContext contain matching parameters.  If not throw exception.
                // Get parameters for matching mapping
                MethodInfo mi = typeof(SiteContext).GetMethod(procName);
                if (mi == null)
                {
                    throw new Exception(String.Format("Stored proc mapping for {0} missing in DBContext", procName));
                }
                ParameterInfo[] methodParams = mi.GetParameters();
                // Finished getting parameters
                // Get parameters from stored proc
                int spParamCount = 0;
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;                    
                    while ((line = reader.ReadLine()) != null) 
                    {
                        // If end of parameter section, break out
                        if (line.ToUpper() == "BEGIN")
                        {
                            break;
                        }
                        else
                        {
                            if (line.Contains("@"))
                            {
                                spParamCount++;
                            }
                        }                        
                    }
                }
                // Finished get parameters from stored proc
                if (methodParams.Count() != spParamCount)
                {
                    string err = String.Format("Stored proc mapping for {0} in DBContext exists but has {1} parameter(s)" +
                        " The stored procedure {0} has {2} parameter(s)", procName, methodParams.Count().ToString(), spParamCount.ToString());
                    throw new Exception(err);
                }
                else
                {
                    context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
                }
            }
