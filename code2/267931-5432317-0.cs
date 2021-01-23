    if ((txtEmployeeID.TextLength != 0) && (enteredDate.Length != 0))
                {
                    int ID = Convert.ToInt32(txtEmployeeID.Text);
                    employeesBindingSource.Filter = "EmployeeID ='" + txtEmployeeID.Text + "'";
                    String birthDate;
                    birthDate = dsEmployees.Employees.FindByEmployeeID(ID).BirthDate.ToShortDateString();    // FROM HERE
                    if (employeesBindingSource.Count != 0)
                    {
                        sqlConnectionNW.Close();
