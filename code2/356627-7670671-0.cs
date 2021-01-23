    namespace BO.Factory
        {
            public class CFactory
            {
        
                public static object getClassInstance(string key, params  object[] constructorArgs)
                {
                    try
                    {
                        string assemblyPath = null;
                        string customClassName = null;
                        DataSet objDataset = getAssemblyInfo(key);
                        if (objDataset != null && objDataset.Tables.Count > 0 && objDataset.Tables[0].Rows.Count > 0)
                        {
                            assemblyPath = objDataset.Tables[0].Rows[0]["ACA_ASSEMBLY_PATH"].ToString();
                            customClassName = objDataset.Tables[0].Rows[0]["ACA_CLASS_NAME"].ToString();
                        }
        
                        Assembly assembly;
                        Type type;
                        string className;
        
                        if (assemblyPath != null && assemblyPath != string.Empty)
                        {
                            assembly = Assembly.LoadFile(assemblyPath);
                            className = customClassName;
                        }
                        else // if no customisation
                        {
                            assembly = key.Split('.')[1].ToString() == "BO" ? typeof(Catalyst.BO.SchoolBO.CSchoolBO).Assembly : typeof(Catalyst.DAL.SchoolDAO.CSchoolDAO).Assembly;
                            className = key;
                        }
        
                        type = assembly.GetType(className, true, true);
        
                        object classInstance = constructorArgs == null ? Activator.CreateInstance(type) : Activator.CreateInstance(type, constructorArgs);
                        if (classInstance == null) throw new Exception("broke");
                        return classInstance;
                    }
                    catch (Exception e)
                    {
                        throw (e);
                    }
        
                }
        
                static DataSet getAssemblyInfo(string key)
                {
                    try
                    {
                        string cmdText = "SELECT ACA_ID,ACA_KEY,ACA_ASSEMBLY_PATH,ACA_CLASS_NAME "
                                        + "FROM ADM_CUSTOM_ASSEMBLY_INFO "
                                        + "WHERE ACA_KEY='" + key + "'";
        
                        System.Data.SqlClient.SqlCommand sqlcommand = new System.Data.SqlClient.SqlCommand(cmdText);
        
                        DAL.DBHelper.CDBHelper objCDBHelper = new Catalyst.DAL.DBHelper.CDBHelper();
        
                        return objCDBHelper.PopulateDS(sqlcommand);
                    }
                    catch
                    {
                        return null;
                    }
        
                }
            }
        }
