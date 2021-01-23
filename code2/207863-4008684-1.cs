        List<Customer> CustomerList = new List<Customer>();
        List<Orders> Orders = new List<Orders>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add some customers
            CustomerList.Add(new Customer() { CustomerId = 1, CompanyName = "TestCompany", FirstName = "John", LastName = "West" });
            CustomerList.Add(new Customer() { CustomerId = 2, CompanyName = "AnotherCompany", FirstName = "Alan", LastName = "East" });
            // Add some orders
            Orders.Add(new Orders() { CustomerId = 1, OrderId = 1, OrderDate = DateTime.Now, Sum = 300 });
            Orders.Add(new Orders() { CustomerId = 1, OrderId = 2, OrderDate = DateTime.Now, Sum = 600 });
            Orders.Add(new Orders() { CustomerId = 2, OrderId = 3, OrderDate = DateTime.Now, Sum = 2000 });
            Orders.Add(new Orders() { CustomerId = 2, OrderId = 4, OrderDate = DateTime.Now, Sum = 100 });
            // Bind customerlist to grid
            CustomerGrid.DataSource = CustomerList;
            CustomerGrid.DataBind();
        }
        protected void CustomerGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get customer id for row
                int customerId = (int)CustomerGrid.DataKeys[e.Row.RowIndex].Value;
                // Get the nested grid control
                GridView OrderGrid = e.Row.FindControl("OrderGrid") as GridView;
                // Get orders for customer
                OrderGrid.DataSource = Orders.Where(o => o.CustomerId == customerId);
                OrderGrid.DataBind();
            }
        }
      
