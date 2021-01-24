    Private void FillDGV()
    {
        String cmdText = "SELECT workers.FNAME, workers.LNAME FROM project1.workers INNER JOIN project1.order_status " + "ON workers.ID_WORKER = order_status.ID_WORKER INNER JOIN project1.orders ON orders.ID_ORDER = order_status.ID_ORDER " + "WHERE orders.ORDER_NUMBER = '" + NrOrder + "' GROUP BY workers.FNAME, workers.LNAME\"; ";
        DataSet ds;
        ds = DAL.GetQueryResults(cmdText);
        DataTable dt;
        if (ds.Tables.Count > 0)
        {
            dt = ds.Tables(0);
            this.DataGridView1.DataSource = dt;   // fill DataGridView
        }
    }
