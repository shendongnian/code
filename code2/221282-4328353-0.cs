	private string GetSupervisorFullName(string entityID, string connectionString) {
		string query = "Select Supervisor_FirstName + ' ' + Supervisor_LastName as Supervisor_FullName From Supervisors Where Supervisor_ID = @EntityID";
		string supervisorFullname = "";
		
		using(SqlConnection con = new SqlConnection(connectionString)) {
			SqlCommand cmdSupervisorFullname = new SqlCommand();
			cmdSupervisorFullname.Connection = con;
			cmdSupervisorFullname.CommandText = query;
			cmdSupervisorFullname.CommandType = CommandType.Text;
			
			SqlParameter paraEntityID = new SqlParameter();
			paraEntityID.ParameterName = "@EntityID";
			paraEntityID.SqlDbType = SqlDbType.NVarChar;
			paraEntityID.Direction = ParameterDirection.Input;
			paraEntityID.Value = entityID;
			
			cmdSupervisorFullname.Parameters.Add(paraEntityID);
			
			try {
				con.Open();
				supervisorFullname = (String) cmdSupervisorFullname.ExecuteScalar();
			} catch(Exception ex) {
				Console.WriteLine(ex.Message);
			}
			
			return supervisorFullname;
		}
	}
