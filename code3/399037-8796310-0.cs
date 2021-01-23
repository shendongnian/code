	var comparer = StringComparer.OrdinalIgnoreCase;
	var namesAndSalaries = new List<Tuple<Employee, Employee>>();
	var namesOnly = new List<Tuple<Employee, Employee>>();
	
	// Create 2 iterators; one for old, one for new:
	using (IEnumerator<Employee> old = oldEmployeeList.GetEnumerator()) {
		foreach (Employee newCurrent in newEmployeeList) {
			while (old.MoveNext()) {
				int compared = comparer.Compare(old.Current.name, newCurrent.name);
				if (compared == 0) {
					// Names match
					if (old.Current.salary == newCurrent.salary) {
						namesAndSalaries.Add(Tuple.Create(old.Current, newCurrent));
					} else {
						namesOnly.Add(Tuple.Create(old.Current, newCurrent));
					}
				} else if (compared == 1) {
					// Keep searching old
					continue;
				} else {
					// Keep searching new
					break;
				}
				
			}
		}
	}
	
