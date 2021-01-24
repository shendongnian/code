    public IHttpActionResult GetEmployees()
        {
            var query = (from n in db.Employees
                     join c in db.tblCities on n.ProjectID equals c.CityID
    
                     select new
                     {
                         n.Name,
                         n.Email,
                         c.CityName
                     });
    
           var employees = query.ToList();
     
           //some other things, maybe you want to return BadRequest if there are none or NotFound or whatever you deem appropriate
           return Ok(employees);           
        }
