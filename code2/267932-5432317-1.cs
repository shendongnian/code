                    int ID = Convert.ToInt32(txtEmployeeID.Text);
                    employeesBindingSource.Filter = "EmployeeID ='" + txtEmployeeID.Text + "'";
                    String birthDate;
                    if (employeesBindingSource.Count != 0)
                    {
                        birthDate = dsEmployees.Employees.FindByEmployeeID(ID).BirthDate.ToShortDateString();    //TO HERE
                        sqlConnectionNW.Close();
