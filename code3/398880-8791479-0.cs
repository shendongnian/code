        private void GetSqlDefaultInfo(string InstanceName, string ServerName)
        {
            try
            {
                InstanceName = string.IsNullOrEmpty(InstanceName) ? "MSSQLSERVER" : InstanceName;
                if (string.IsNullOrEmpty(ServerName))
                    ServerName = Environment.MachineName;
                using (var registryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, ServerName))
                {
                    object sqlInstance;
                    using (var subKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
                        sqlInstance = subKey.GetValue(InstanceName);
                    if (sqlInstance != null && !string.IsNullOrEmpty(sqlInstance.ToString()))
                    {
                        var sqlPathKey = string.Format(@"SOFTWARE\Microsoft\Microsoft SQL Server\{0}\MSSQLServer",
                                                       sqlInstance);
                        object defaultData, defaultLog, backupDirectory, sqlPath;
                        using (var subKey = registryKey.OpenSubKey(sqlPathKey))
                        {
                            defaultData = subKey.GetValue("DefaultData");
                            defaultLog = subKey.GetValue("DefaultLog");
                            backupDirectory = subKey.GetValue("BackupDirectory");
                        }
                        sqlPathKey = string.Format(@"SOFTWARE\Microsoft\Microsoft SQL Server\{0}\Setup", sqlInstance);
                        
                        using (var subKey = registryKey.OpenSubKey(sqlPathKey))
                            sqlPath = subKey.GetValue("SQLDataRoot");
                        DataFilePath = defaultData != null
                                           ? defaultData.ToString()
                                           : Path.Combine(sqlPath.ToString(), "Data").TrimEnd('\\');
                        LogFilePath = defaultLog != null
                                          ? defaultLog.ToString()
                                          : Path.Combine(sqlPath.ToString(), "Data").TrimEnd('\\');
                        FTSIndexFilePath = DataFilePath;
                        ContentFilePath = DataFilePath;
                        BackupFilePath = backupDirectory != null
                                             ? backupDirectory.ToString()
                                             : Path.Combine(sqlPath.ToString(), "Backup").TrimEnd('\\');
                    }
                }
            } catch(Exception)
            {
            }
        }
