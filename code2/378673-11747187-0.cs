    using System.Text;
    using CrystalDecisions.Shared;
    using System.Data.SqlClient;
    
    namespace StackOverflow
    {
    	public class MyCrystalReports
    	{
    
    		// This method will allow you may easily set report datasource  based on your current SqlServerConnetion
    		public static void SetSqlConnection(CrystalDecisions.CrystalReports.Engine.ReportClass MyReport, SqlConnection MySqlConnection)
    		{
    
    			// You may even test SqlConnection before using it.
    
    			SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder(MySqlConnection.ConnectionString);
    
    			string ServerName = SqlConnectionStringBuilder.DataSource;
    			string DatabaseName = SqlConnectionStringBuilder.InitialCatalog;
    			Boolean IntegratedSecurity = SqlConnectionStringBuilder.IntegratedSecurity;
    			string UserID = SqlConnectionStringBuilder.UserID;
    			string Password = SqlConnectionStringBuilder.Password;
    			// Of course, you may add extra settings here :D
    
    			// On Crystal Reports, connection must be set individually for each  table defined on the report document
    			foreach (CrystalDecisions.CrystalReports.Engine.Table Table in MyReport.Database.Tables)
    			{
    
    				CrystalDecisions.Shared.TableLogOnInfo TableLogOnInfo = Table.LogOnInfo;
    
    				TableLogOnInfo.ConnectionInfo.ServerName = ServerName;
    				TableLogOnInfo.ConnectionInfo.DatabaseName = DatabaseName;
    				TableLogOnInfo.ConnectionInfo.IntegratedSecurity = IntegratedSecurity;
    
    				if (IntegratedSecurity != true)
    				{
    					TableLogOnInfo.ConnectionInfo.UserID = UserID;
    					TableLogOnInfo.ConnectionInfo.Password = Password;
    				}
    
    				Table.ApplyLogOnInfo(TableLogOnInfo);
    
    			}
    		}
    
    	}
    }
