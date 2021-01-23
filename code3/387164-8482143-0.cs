            // Assuming conn is an open SqlConnection
            System.Text.StringBuilder sbSQL = new StringBuilder(500);
            SqlParameterCollection cParameters = new SqlParameterCollection();
            // Add a default condition of 1=1 so that all subsequent conditions can be added 
            // with AND instead of having to check to see whether or not any other conditions
            // were added before adding AND.
            sbSQL.Append("SELECT * FROM MyTestTable WHERE 1 = 1 ");
            if (!String.IsNullOrEmpty(txtCondition1.Text)) {
                sbSQL.Append(" AND Column1 = @Column1");
                cParameters.Add(new SqlParameter("@Column1", txtCondition1.Text));
            }
            if (!String.IsNullOrEmpty(txtCondition1.Text))
            {
                sbSQL.Append(" AND Column2 = @Column2");
                cParameters.Add(new SqlParameter("@Column2", txtCondition2.Text));
            }
            SqlCommand oCommand = new SqlCommand(sbSQL.ToString, conn);
            foreach (SqlParameter oParameter in cParameters)
            {
                oCommand.Parameters.Add(oParameter);
            }
            // Do something with oCommand
