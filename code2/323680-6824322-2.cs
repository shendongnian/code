    public static void LocateSqlInstances()
      {
         using (DataTable sqlSources = SqlDataSourceEnumerator.Instance.GetDataSources())
         {
            foreach (DataRow source in sqlSources.Rows )
            {
               string servername;
               string instanceName = source["InstanceName"].ToString();
    
               if (!string.IsNullOrEmpty(instanceName))
               {
                  servername =  source["InstanceName"] + '\\' + source["ServerName"];
               }
               else
               {
                  servername =  source["ServerName"];
               }
               Console.WriteLine(" Server Name:{0}", servername );
               Console.WriteLine("     Version:{0}", source["Version"]);
               Console.WriteLine();
               
            }
            Console.ReadKey();
         }
      }
