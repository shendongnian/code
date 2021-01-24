    var jsonSerialiser = new JavaScriptSerializer();
            string json = "";
            DataTable dt = new DataTable();
            dt = Common.GetData(txtDateFrom.Text, txtDateTo.Text);
            DataView dv = new DataView(dt);
            dv.Sort = "MobileNumber, Date";
            string oldID = "";
            List<History> history = new List<History>();
            List<CustomerList> customerLists = new List<CustomerList>();
            List<Customer> customer = new List<Customer>();
            foreach (DataRowView row in dv)
            {
                if (string.IsNullOrEmpty(oldID))
                {
    
                    history.Add(new History
                    {
                        DealerID = row["DealerID"].ToString(),
                        VisitedStoreName = row["DealerName"].ToString(),
                        VisitedDate = row["Date"].ToString(),
                        Activity = row["Activity"].ToString(),
                        VehicleID = row["VehicleID"].ToString(),
                        VehicleName = row["CarModel"].ToString(),
                        OCN = row["OCN"].ToString(),
                        Source = row["Source"].ToString()
                    });
    
                    oldID = row["CustomerID"].ToString();
                }
                else if (oldID.Equals(row["CustomerID"].ToString(), StringComparison.InvariantCultureIgnoreCase)) //compare old to new
                {
                    history.Add(new History
                    {
                        DealerID = row["DealerID"].ToString(),
                        VisitedStoreName = row["DealerName"].ToString(),
                        VisitedDate = row["Date"].ToString(),
                        Activity = row["Activity"].ToString(),
                        VehicleID = row["VehicleID"].ToString(),
                        VehicleName = row["CarModel"].ToString(),
                        OCN = row["OCN"].ToString(),
                        Source = row["Source"].ToString()
                    });
                }
                else
                {
    
                    //{
                    customer.Add(new Customer { INI_CUSTOMER_ID = oldID, History = history });
                    //}; 
    
                    //json += JsonConvert.SerializeObject(customerLists);
                    //clear the history list
                    history.Clear();
    
                    //start a new set
                    history.Add(new History
                    {
                        DealerID = row["DealerID"].ToString(),
                        VisitedStoreName = row["DealerName"].ToString(),
                        VisitedDate = row["Date"].ToString(),
                        Activity = row["Activity"].ToString(),
                        VehicleID = row["VehicleID"].ToString(),
                        VehicleName = row["CarModel"].ToString(),
                        OCN = row["OCN"].ToString(),
                        Source = row["Source"].ToString()
                    });
    
                    oldID = row["CustomerID"].ToString();
                }
            }
    
            json = JsonConvert.SerializeObject(new CustomerList
            {
               Customers = customer
            });
