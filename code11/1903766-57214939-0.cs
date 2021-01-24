        [HttpGet]
        [Route("api/GetEmp")]
        public Employee GetEmp([FromBody]Employee employee)
        {
            // Getting employee object from client
            // Yet to implement
            if (employee != null)
            {
                employee.Designation = "Engineer";
            }
            return employee;
        }
 
