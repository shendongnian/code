    private void LoaddEmployees()
        {
            try
            {
                db = new EmployeeEntities();
                var employees = (from u in db.Users.ToList()
                                 select new
                                 {
                                     EmployeeId = u.EmployeeId,
                                     UserName = u.UserName,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     Birthday = u.Birthday,
                                     Age = CalculateAge(u.Birthday) // note that we are sending in the Birthday
                                 }).ToList();
                dgvEmployeesList.DataSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
