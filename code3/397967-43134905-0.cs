    public void SaveConnectionString(DbInfo dbinfo, string path,string appConfigFile)
        {
            try
            {
                string configFile = Path.Combine(path, appConfigFile);
                var doc = new XmlDocument();
                doc.Load(configFile);
                XmlNodeList endpoints = doc.GetElementsByTagName("connectionStrings");
                foreach (XmlNode item in endpoints)
                {
                    if (item.HasChildNodes)
                    {
                        foreach (var c in item.ChildNodes)
                        {
                            if (((XmlNode)c).NodeType == XmlNodeType.Element)
                            {
                                var adressAttribute = ((XmlNode)c).Attributes["name"];
                                if (adressAttribute.Value.Contains("YourConStrName"))
                                {
                                    if (dbinfo.dbType == dataBaseType.Embedded)
                                    {
                                        ((XmlNode)c).Attributes["connectionString"].Value = SetupConstants.DbEmbededConnectionString;
                                        ((XmlNode)c).Attributes["providerName"].Value = SetupConstants.DbEmbededConnectionProvider;
                                    }
                                    else if (dbinfo.dbType == dataBaseType.Microsoft_SQL_Server)
                                    {
                                        if (dbinfo.sqlServerAuthType == SqlServerAuthenticationType.SQL_Server_Authentication)
                                        {
                                           // ((XmlNode)c).Attributes["connectionString"].Value = string.Format(SetupConstants.dbConnStringwithDb, dbinfo.databaseAdress, SetupConstants.SqlDbName, dbinfo.userId, dbinfo.password) + "MultipleActiveResultSets=true;";
                                            ((XmlNode)c).Attributes["connectionString"].Value = string.Format(SetupConstants.dbConnStringwithDb, dbinfo.databaseAdress, dbinfo.DatabaseName, dbinfo.userId, dbinfo.password) + "MultipleActiveResultSets=true;";
                                        }
                                        else if (dbinfo.sqlServerAuthType == SqlServerAuthenticationType.Windows_Authentication)
                                        {
                                            //((XmlNode)c).Attributes["connectionString"].Value = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=true;", dbinfo.databaseAdress, SetupConstants.SqlDbName);
                                            ((XmlNode)c).Attributes["connectionString"].Value = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=true;", dbinfo.databaseAdress, dbinfo.DatabaseName);
                                        }
                                        ((XmlNode)c).Attributes["providerName"].Value = SetupConstants.DbSqlConnectionProvider;
                                    }
                                }
                            }
                        }
                    }
                }
                doc.Save(configFile);
                string exePath = Path.Combine(path, "EDC.Service.exe");
                InstallerHelper.EncryptConnectionString(true, exePath);
            }
            catch (Exception ex)
            {
                //TODO://log here exception
                Helper.WriteLog(ex.Message + "\n" + ex.StackTrace);
                throw;
            }
        }
