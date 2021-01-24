     switch (getType[i])
    {
        case "A":
            float yearAbsence = oracleConn.SelectAbsenceType(EmployeeID)
                .Where(k => k.Type == "A")
                .GroupBy(g => g.Type)
                .Select(h => h.Sum(s => s.TotalHour));
            // add to the list:
            result.Add(new SigningAbsenceType
            {
                YearAbsence = yearAbsence,
                SickAbsence = 0.0f;
            });
 
