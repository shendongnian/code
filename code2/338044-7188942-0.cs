     SqlDataSourceEnumerator sqldatasourceenumerator1 = SqlDataSourceEnumerator.Instance;
                DataTable datatable1 = sqldatasourceenumerator1.GetDataSources();
                foreach (DataRow row in datatable1.Rows)
                {
                    if (Environment.MachineName.Equals(row["ServerName"]))
                    {
    
                        isSqlServerPresent = true;
                        break;
                    }
                }
