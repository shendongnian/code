        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<Employee> empList = GetEmployeeDetails();
            DataSet dataset = new DataSet("DataSet");
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1.TableName = "Employee";
            dt1.Columns.Add("EmpId");
            dt1.Columns.Add("Name");
            dt1.Columns.Add("Age");
            dataset.Tables.Add(dt1);
            System.Data.DataTable dt2 = new System.Data.DataTable();
            dt2.TableName = "Address";
            dt2.Columns.Add("EmpId");
            dt2.Columns.Add("Street");
            dt2.Columns.Add("City");
            dt2.Columns.Add("Zip");
            dataset.Tables.Add(dt2);
            foreach (Employee emp in empList)
            {
                dt1.Rows.Add(new object[] { emp.EmpId, emp.Name, emp.Age });
                foreach (Address add in emp.Address)
                {
                    dt2.Rows.Add(new object[] { emp.EmpId, add.Street, add.City, add.Zip });
                }
            }
            
            RadGrid1.MasterTableView.DataSource = dataset.Tables["Employee"];
            RadGrid1.MasterTableView.DetailTables[0].DataSource = dataset.Tables["Address"];
            
        }
