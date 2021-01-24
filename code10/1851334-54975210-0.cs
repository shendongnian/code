    {
    var jsonSerialiser = new JavaScriptSerializer();
                string json = "";
                DataTable dt = new DataTable();
                dt = Common.GetData(txtDateFrom.Text, txtDateTo.Text);
                DataView dv = new DataView(dt);
                dv.Sort = "MobileNumber, Date";
                string oldID = "";
                List<CustomerList> customerLists = new List<CustomerList>();
                List<Customer> customer = new List<Customer>();
                foreach (DataRowView row in dv)
                {
                    if (string.IsNullOrEmpty(oldID))
                    {
                        List<History> history = new List<History>()
                        {
                            new History{
                            DealerID = row["DealerID"].ToString(),
                            VisitedStoreName = row["DealerName"].ToString(),
                            VisitedDate = row["Date"].ToString(),
                            Activity = row["Activity"].ToString(),
                            VehicleID = row["VehicleID"].ToString(),
                            VehicleName = row["CarModel"].ToString(),
                            OCN = row["OCN"].ToString(),
                            Source = row["Source"].ToString()}
                        };
                        oldID = row["CustomerID"].ToString();
                        customer.Add(new Customer {INI_CUSTOMER_ID = oldID, History = history});
                    }
                    else if(oldID.Equals(row["CustomerID"].ToString(), StringComparison.InvariantCultureIgnoreCase)) //compare old to new
                    {
                        List<History> history = new List<History>()
                        {
                            new History{
                            DealerID = row["DealerID"].ToString(),
                            VisitedStoreName = row["DealerName"].ToString(),
                            VisitedDate = row["Date"].ToString(),
                            Activity = row["Activity"].ToString(),
                            VehicleID = row["VehicleID"].ToString(),
                            VehicleName = row["CarModel"].ToString(),
                            OCN = row["OCN"].ToString(),
                            Source = row["Source"].ToString()}
                        };
                        customer.Add(new Customer { INI_CUSTOMER_ID = oldID, History = history});
                    }
                    else
                    {
                        List<History> history = new List<History>()
                        {
                            new History{
                            DealerID = row["DealerID"].ToString(),
                            VisitedStoreName = row["DealerName"].ToString(),
                            VisitedDate = row["Date"].ToString(),
                            Activity = row["Activity"].ToString(),
                            VehicleID = row["VehicleID"].ToString(),
                            VehicleName = row["CarModel"].ToString(),
                            OCN = row["OCN"].ToString(),
                            Source = row["Source"].ToString()}
                        };
                        oldID = row["CustomerID"].ToString();
                        customer.Add(new Customer { INI_CUSTOMER_ID = oldID, History = history });
                    }
                }
    
                foreach (var obj in customer.ToList())
                {
                    var currentItem = customer.FindIndex(a => a.INI_CUSTOMER_ID.ToUpper() == obj.INI_CUSTOMER_ID.ToUpper()); //customer.IndexOf(obj);
                 for (int i = currentItem + 1; i < customer.Count; i++)
                    {
                        if (customer[currentItem].INI_CUSTOMER_ID.ToUpper() == customer[i].INI_CUSTOMER_ID.ToUpper())
                        {
                            customer[currentItem].History.InsertRange(customer[i].History.Count,customer[i].History);
                            customer.RemoveAt(i);
                        }
                    }
                }
                List<Customers> customers = new List<Customers>()
                {
                    new Customers
                    {
                        CUSTOMERS = customer
                    }
                };
                json = JsonConvert.SerializeObject(customers);
                Console.Write(json);
            }
