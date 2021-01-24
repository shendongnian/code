    var getType = oracleConn.SelectAbsenceType(EmployeeID).Select(t => t.Type).Distinct().ToArray();
    IList<SigningAbsenceType> result = new List<SigningAbsenceType>();
    
    var tempResult = getType.Select(t => {
        switch (t)
        {
            case "A":
                var YearAbsence = oracleConn.SelectAbsenceType(EmployeeID)
                    .Where(k => k.Type == "A")
                    .GroupBy(g => g.Type)
                    .Select(h => new
                    {
                        TotalHour = h.Sum(s => s.TotalHour)
                    }).Single();
                return new SigningAbsenceType(){ YearAbsence = YearAbsence.TotalHour };
            case "S":
                var SickAbsence = oracleConn.SelectAbsenceType(EmployeeID)
                    .Where(k => k.Type == "S")
                    .GroupBy(g => g.Type)
                    .Select(h => new
                    {
                        TotalHour = h.Sum(s => s.TotalHour)
                    }).Singe();
                return new SigningAbsenceType(){ SickAbsence = SickAbsence.TotalHour };
        }
    });
    result.AddRange(tempResult);
       
    return result;
