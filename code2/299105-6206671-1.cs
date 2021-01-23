    var sortedNames = empList.Where(e => e.Shift >= 0 && e.Shift < MAX_SHIFT)
                             .OrderBy(e => e.Shift)
                             .ThenBy(e => e.LastName)
                             .ThenBy(e => e.FirstName)
                             .Select(e => string.Format("{0}, {1}", e.Lastname, e.Firstname))
                             .ToList();
