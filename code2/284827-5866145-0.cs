        // 3. Pass the connection to a command object
        SqlCommand cmd=new SqlCommand ("insert into time(project,iteration) values (@project, @iteration)", conn); // ", conn)" added
        cmd.Parameters.Add("project", System.Data.SqlDbType.NVarChar).Value = this.name1.SelectedValue;
        cmd.Parameters.Add("iteration", System.Data.SqlDbType.NVarChar).Value = this.name1.SelectedValue;
        //
        // 4. Use the connection
        //
