    public string GetEmployees(){
            //Get Employees from Db:
            var employessFromDb = _context.Employees.ToList(); //Where Employees is your table name
            //Generate JSON string that we want to return
            string JSON = JsonConvert.SerializeObject(employessFromDb);
            //return the JSON
            return JSON;
    }
