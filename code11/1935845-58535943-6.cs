        [HttpGet]
        [Route("AllEmployeeDetailsInJSON")]
        public IHttpActionResult GetEmployeeInJSON()
        {
            try
            {
                var employeesFromDb = _context.Employees.ToList(); //Where Employees is your table name
                return Ok(employeesFromDb);
            }
            catch (Exception)
            {
                throw;
            }
        }
