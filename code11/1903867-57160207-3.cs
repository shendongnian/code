    switch (getType[i])
    {
        case "A":
            IEnumerable<float> fetchedYearAbsences = oracleConn
                .SelectAbsenceType(EmployeeID)
                .Where(k => k.Type == "A")
                .GroupBy(g => g.Type)
                .Select(h => h.Sum(s => s.TotalHour));
            // add to the list:
            foreach (float fetchedYearAbsence in fetchedYearAbsences)
            {
                 result.Add(new SigningAbsenceType
                {
                    YearAbsence = fetchedYearAbsence,
                    SickAbsence = 0.0f;
                });
            }
            break;
