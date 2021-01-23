	var comparer = StringComparer.OrdinalIgnoreCase;
	var namesAndSalaries = new List<Tuple<Employee, Employee>>();
	var namesOnly = new List<Tuple<Employee, Employee>>();
	
	// Create 2 iterators; one for old, one for new:
	using (IEnumerator<Employee> A = oldEmployeeList.GetEnumerator()) {
		using (IEnumerator<Employee> B = newEmployeeList.GetEnumerator()) {
			// Start enumerating both:
			if (A.MoveNext() && B.MoveNext()) {
				while (true) {
					int compared = comparer.Compare(A.Current.name, B.Current.name);
					if (compared == 0) {
						// Names match
						if (A.Current.salary == B.Current.salary) {
							namesAndSalaries.Add(Tuple.Create(A.Current, B.Current));
						} else {
							namesOnly.Add(Tuple.Create(A.Current, B.Current));
						}
						if (!A.MoveNext() || !B.MoveNext()) break;
					} else if (compared == -1) {
						// Keep searching A
						if (!A.MoveNext()) break;
					} else {
						// Keep searching B
						if (!B.MoveNext()) break;
					}
					
				}
			}
		}
	}
	
