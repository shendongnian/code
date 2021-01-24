    public async Task<List<Documents>> GetDocument(string ownerId, string dependentId)
            {
                var query = (from employee in _employee.AsQueryable()
                            where employee.ownerId == ownerId
                            select new Employee()
                            {
                               DependentsDocuments  = employee.DependentsDocuments.Where(x => x.dependentId == dependentId).ToList()                            
                            }).ToList();               
                return query.ToList();
            }
