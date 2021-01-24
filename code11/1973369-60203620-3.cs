        List<EmpVacations> empVacations = new List<EmpVacations>();
        foreach (var emp in employees)
                {
                    EmpVacations emp1 = new EmpVacations();
                    emp1.EmpId = emp.Id;
                    emp1.EmpName = emp.Name;
                    emp1.AllowedRegularVacation = emp.RegularVacations;
                    emp1.AllowedCasualVacation = emp.CasualVacations;
                    emp1.TakenRegularVacation = countOrdinaryVacation.Where(x => x.key == emp1.EmpId).FirstOrDefault() == null ? 0 : countOrdinaryVacation.Where(x => x.key == emp1.EmpId).FirstOrDefault().OrdinaryVaction;
                    emp1.TakenCasualVacation = countCasualVacation.Where(x => x.key == emp1.EmpId).FirstOrDefault() ==null ? 0 : countCasualVacation.Where(x => x.key == emp1.EmpId).FirstOrDefault().CasualVacation;
                emp1.RemRegularVacation = emp1.AllowedRegularVacation - emp1.TakenRegularVacation;
                emp1.RemCasualVacation = emp1.AllowedCasualVacation - emp1.TakenCasualVacation;
                empVacations.Add(emp1);
                    }
