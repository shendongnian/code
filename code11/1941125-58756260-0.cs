	var duplicates =
		from p1 in persons
		from p2 in persons
		where p1.Id != p2.Id && (
			(p1.SSN == p2.SSN && p1.LastName == p2.LastName) ||
			(p1.FirstName == p2.FirstName && p1.LastName == p2.LastName && p1.BirthDate == p2.BirthDate))
		select new { Person1 = p1, Person2 = p2 };
