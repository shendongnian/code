        DataTable dt = new DataTable();
        dt.Columns.Add("DepAmt", typeof(double));
        dt.Columns.Add("DepDate", typeof(DateTime));
        dt.Columns.Add("DepositId", typeof(int));
        dgvDeposits.DataSource = dt;       
