        public static IEnumerable<Employee> GetTreeForEmployeeNumber(this IEnumerable<Employee> source, int startingId) {
    		var result = source.Where(x => x.EmployeeId == startingId).FirstOrDefault();
    		if (result != null) {
    			var resultAsE = new [] { result };
    			if (!result.ManagerId.HasValue)
    				return resultAsE;
    			return resultAsE.Union(source.Except(resultAsE).GetTreeForEmployeeNumber(result.ManagerId.Value));
    		}
    		return new Employee [] { };
    	}
