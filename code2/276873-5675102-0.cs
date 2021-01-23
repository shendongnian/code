            for (int i = 0; i < GridViewOrder.Rows.Count; i++)
            {
                CheckBox ck = (CheckBox)GridViewOrder.Rows[i].Cells[0].FindControl("CheckBoxATH");
                Label orderID = (Label)GridViewOrder.Rows[i].Cells[5].FindControl("LabelOrderID");
                if (ck != null)
                {
                    string conn = "Data Source=pc-...";
                    System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(conn);
                    sqlConn.Open();
                    System.Data.SqlClient.SqlCommand updateCommand = new System.Data.SqlClient.SqlCommand("UPDATE tblOrders SET tOrderATH = '" + ck.Checked + "' WHERE tOrderId= '" + orderID.Text + "'", sqlConn);
                    updateCommand.Parameters.AddWithValue("@orderID", orderID.Text);
                    updateCommand.ExecuteNonQuery();
                }
            }
