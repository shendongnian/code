        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            var ctx = new LinqDataSource.DBDataContext();
            IQueryable<Customer> customers = ctx.Customers;
            if (!String.IsNullOrEmpty(txtLastName.Text))
                customers = customers.Where ( c => c.LastName.Contains(txtLastName.Text));
            e.Result = customers;
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
