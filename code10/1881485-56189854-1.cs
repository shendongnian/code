    string query = @"INSERT INTO dbo.ImportedProjects 
                        (
                            KeyProject, 
                            KeyCompany, 
                            KeyCountry, 
                            KeyCustomer, 
                            KeyEmployeeProjectManager, 
                            KeyEmployeeProjectOwner, 
                            KeyOrganisation, 
                            ProjectNumber, 
                            ProjectName, 
                            ProjectOwnerNumber, 
                            ProjectManagerNumber, 
                            ProjectOwnerName, 
                            ProjectManagerName, 
                            ProjectOwnerInitials, 
                            ProjectManagerInitials, 
                            CustomerNumber, 
                            CustomerName, 
                            CreatedDate, 
                            ProjectStatus, 
                            ProjectOpenClosed
                        ) VALUES (
                            @KeyProject, 
                            @KeyCompany, 
                            @KeyCountry, 
                            @KeyCustomer, 
                            @KeyEmployeeProjectManager, 
                            @KeyEmployeeProjectOwner, 
                            @KeyOrganisation, 
                            @ProjectNumber, 
                            @ProjectName, 
                            @ProjectOwnerNumber, 
                            @ProjectManagerNumber, 
                            @ProjectOwnerName, 
                            @ProjectManagerName, 
                            @ProjectOwnerInitials, 
                            @ProjectManagerInitials, 
                            @CustomerNumber, 
                            @CustomerName, 
                            @CreatedDate, 
                            @ProjectStatus, 
                            @ProjectOpenClosed
                        )";
        SqlConnection sqlCon = new SqlConnection("Server=localhost;Database=DatabaseName;Trusted_Connection=True;");
        SqlCommand idInsertCms = new SqlCommand("SET IDENTITY_INSERT dbo.ImportedProjects ON", sqlCon);
        
        try
        {
            sqlCon.Open();
            idInsertCms.ExecuteNonQuery();
            foreach (var item in importedProjects)
            {
			    SqlCommand sqlCmd= new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.Add("@KeyProject", SqlDbType.Int);
                sqlCmd.Parameters["@KeyProject"].Value = item.KeyProject;
                sqlCmd.Parameters.Add("@KeyCompany", SqlDbType.Int);
                sqlCmd.Parameters["@KeyCompany"].Value = item.KeyCompany;
                sqlCmd.Parameters.Add("@KeyCountry", SqlDbType.Int);
                sqlCmd.Parameters["@KeyCountry"].Value = item.KeyCountry;
                sqlCmd.Parameters.Add("@KeyCustomer", SqlDbType.Int);
                sqlCmd.Parameters["@KeyCustomer"].Value = item.KeyCustomer;
                sqlCmd.Parameters.Add("@KeyEmployeeProjectManager", SqlDbType.Int);
                sqlCmd.Parameters["@KeyEmployeeProjectManager"].Value = item.KeyEmployeeProjectManager;
                sqlCmd.Parameters.Add("@KeyEmployeeProjectOwner", SqlDbType.Int);
                sqlCmd.Parameters["@KeyEmployeeProjectOwner"].Value = item.KeyEmployeeProjectOwner;
                sqlCmd.Parameters.Add("@KeyOrganisation", SqlDbType.Int);
                sqlCmd.Parameters["@KeyOrganisation"].Value = item.KeyOrganisation;
                sqlCmd.Parameters.Add("@ProjectNumber", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectNumber"].Value = item.ProjectNumber;
                sqlCmd.Parameters.Add("@ProjectName", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectName"].Value = item.ProjectName;
                sqlCmd.Parameters.Add("@ProjectOwnerNumber", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectOwnerNumber"].Value = item.ProjectOwnerNumber;
                sqlCmd.Parameters.Add("@ProjectManagerNumber", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectManagerNumber"].Value = item.ProjectManagerNumber;
                sqlCmd.Parameters.Add("@ProjectOwnerName", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectOwnerName"].Value = item.ProjectOwnerName;
                sqlCmd.Parameters.Add("@ProjectManagerName", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectManagerName"].Value = item.ProjectManagerName;
                sqlCmd.Parameters.Add("@ProjectOwnerInitials", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectOwnerInitials"].Value = item.ProjectOwnerInitials;
                sqlCmd.Parameters.Add("@ProjectManagerInitials", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectManagerInitials"].Value = item.ProjectManagerInitials;
                sqlCmd.Parameters.Add("@CustomerNumber", SqlDbType.VarChar);
                sqlCmd.Parameters["@CustomerNumber"].Value = item.CustomerNumber;
                sqlCmd.Parameters.Add("@CustomerName", SqlDbType.VarChar);
                sqlCmd.Parameters["@CustomerName"].Value = item.CustomerName;
                sqlCmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@CreatedDate"].Value = item.CreatedDate;
                sqlCmd.Parameters.Add("@ProjectStatus", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectStatus"].Value = item.ProjectStatus;
                sqlCmd.Parameters.Add("@ProjectOpenClosed", SqlDbType.VarChar);
                sqlCmd.Parameters["@ProjectOpenClosed"].Value = item.ProjectOpenClosed;
                sqlCmd.ExecuteNonQuery();
            }
            idInsertCms.CommandText = "SET IDENTITY_INSERT dbo.ImportedProjects OFF";
            idInsertCms.ExecuteNonQuery();
	SqlCommand sqlCmd= new SqlCommand(query, sqlCon);
	sqlCmd.Parameters.Add("@KeyProject", SqlDbType.Int);
	sqlCmd.Parameters.Add("@KeyCompany", SqlDbType.Int);
	sqlCmd.Parameters.Add("@KeyCountry", SqlDbType.Int);
	sqlCmd.Parameters.Add("@KeyCustomer", SqlDbType.Int);
	sqlCmd.Parameters.Add("@KeyEmployeeProjectManager", SqlDbType.Int);
	sqlCmd.Parameters.Add("@KeyEmployeeProjectOwner", SqlDbType.Int);
	sqlCmd.Parameters.Add("@KeyOrganisation", SqlDbType.Int);
	sqlCmd.Parameters.Add("@ProjectNumber", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectName", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectOwnerNumber", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectManagerNumber", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectOwnerName", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectManagerName", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectOwnerInitials", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectManagerInitials", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@CustomerNumber", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@CustomerName", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
	sqlCmd.Parameters.Add("@ProjectStatus", SqlDbType.VarChar);
	sqlCmd.Parameters.Add("@ProjectOpenClosed", SqlDbType.VarChar);
	foreach (var item in importedProjects)
	{
		sqlCmd.Parameters["@KeyProject"].Value = item.KeyProject;
		sqlCmd.Parameters["@KeyCompany"].Value = item.KeyCompany;
		sqlCmd.Parameters["@KeyCountry"].Value = item.KeyCountry;
		sqlCmd.Parameters["@KeyCustomer"].Value = item.KeyCustomer;
		sqlCmd.Parameters["@KeyEmployeeProjectManager"].Value = item.KeyEmployeeProjectManager;
		sqlCmd.Parameters["@KeyEmployeeProjectOwner"].Value = item.KeyEmployeeProjectOwner;
		sqlCmd.Parameters["@KeyOrganisation"].Value = item.KeyOrganisation;
		sqlCmd.Parameters["@ProjectNumber"].Value = item.ProjectNumber;
		sqlCmd.Parameters["@ProjectName"].Value = item.ProjectName;
		sqlCmd.Parameters["@ProjectOwnerNumber"].Value = item.ProjectOwnerNumber;
		sqlCmd.Parameters["@ProjectManagerNumber"].Value = item.ProjectManagerNumber;
		sqlCmd.Parameters["@ProjectOwnerName"].Value = item.ProjectOwnerName;
		sqlCmd.Parameters["@ProjectManagerName"].Value = item.ProjectManagerName;
		sqlCmd.Parameters["@ProjectOwnerInitials"].Value = item.ProjectOwnerInitials;
		sqlCmd.Parameters["@ProjectManagerInitials"].Value = item.ProjectManagerInitials;
		sqlCmd.Parameters["@CustomerNumber"].Value = item.CustomerNumber;
		sqlCmd.Parameters["@CustomerName"].Value = item.CustomerName;
		sqlCmd.Parameters["@CreatedDate"].Value = item.CreatedDate;
		sqlCmd.Parameters["@ProjectStatus"].Value = item.ProjectStatus;
		sqlCmd.Parameters["@ProjectOpenClosed"].Value = item.ProjectOpenClosed;
		sqlCmd.ExecuteNonQuery();
	}
