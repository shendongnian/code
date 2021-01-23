    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Data.SqlClient;
    
        public object connection()
        {
        	SqlConnection myConnectionString = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Pooling=False");
        	double[] a = new double[6];
        	string myCommand = null;
        	myCommand = "CREATE database soft_billing";
        	SqlCommand cmd = new SqlCommand(myCommand, myConnectionString);
        	try {
        		for (int k = 0; k <= 4; k++) {
        			a(k) = 0.0;
        		}
        		cmd.Connection.Open();
        		cmd.ExecuteNonQuery();
        		t.Enabled = true;
        		t.Interval = 10;
        		ProgressBar1.Value = 0;
        
        		cmd.Connection.Close();
        
        	} catch {
        		Interaction.MsgBox(" Already installed database", MsgBoxStyle.Critical, " MaS InfoTech- Warning");
        
        	}
        	try {
        		SqlConnection cn = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=soft_billing;Integrated Security=True;Pooling=False");
        		string sql = null;
        		sql = "CREATE TABLE customer(cus_name varchar(50) NULL,address varchar(50) NULL,mobno numeric(18, 0) NULL,tin varchar(50) NULL,kg varchar(50) NULL)";
        		cmd = new SqlCommand(sql, cn);
        		// , connection);
        		cmd.Connection.Open();
        		cmd.ExecuteNonQuery();
        		cmd.Connection.Close();
        
        	} catch {
        		Interaction.MsgBox(" Already installed database", MsgBoxStyle.Critical, " MaS InfoTech- Warning");
        
        	}
        }
