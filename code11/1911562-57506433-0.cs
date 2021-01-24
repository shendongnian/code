    private void searchButton_Click(object sender, EventArgs e)
    {
        string headerLine = reader.ReadLine();
        openFileDialog1.ShowDialog();
        searchValue.Text = openFileDialog1.FileName;
        using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
        {        
            List<Employee> employeeList = new List<Employee>();
            while(!reader.EndOfStream)
            {
                var value = reader.ReadLine().Split(',');
                var newEmployee = new Employee
                {
                    firstName = value[0],
                    lastName = value[1],
                    address = value[2],
                    age = value[3],
                    monthlyGrossIncome = value[4],
                    departmentId = value[5],
                    developerType = value[6],
                    taxType = value[7]
                };
                employeeList.Insert(newEmployee);   
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(headerLine);
            employeeDataGridView.DataSource = dataTable;
        }
    }
