    switch (getType[i])
    {
        case "A":
            SigningAbsenceType yearAbsence = oracleConn.SelectAbsenceType(EmployeeID)
                .Where(k => k.Type == "A")
                .GroupBy(g => g.Type)
                .Select(h => new SigningAbsenceType
                {
                    YearAbsence = h.Sum(s => s.TotalHour),
                    SickAbsence = 0.0,
                });
                // now you can add to the list!
                result.Add(yearAbsence);
            break;
        case "S": // something similar
