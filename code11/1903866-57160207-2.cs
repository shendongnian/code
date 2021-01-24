    switch (getType[i])
    {
        case "A":
            IEnumerable<SigningAbsenceType> fetchedSingingAbsences = oracleConn
                .SelectAbsenceType(EmployeeID)
                .Where(k => k.Type == "A")
                .GroupBy(g => g.Type)
                .Select(h => new SigningAbsenceType
                {
                    YearAbsence = h.Sum(s => s.TotalHour),
                    SickAbsence = 0.0,
                })
                .ToList();
                // now you can add the fetched data to the list!
                foreach(SingingAbsence fetchedSigningAbsence in fetchedSingingAbsences)
                {
                    result.AddRange(fetchedSigningAbsence);
                }
            break;
        case "S": // something similar
