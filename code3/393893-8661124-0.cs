    using (conn = new SqlConnection(cString)) {
        conn.Open();
        comm = new SqlCommand(selString, conn);
        DataList1.DataSource = comm.ExecuteReader();
        DataList1.DataBind();
        }
