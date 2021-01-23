    IEnumerable<Employee> result = list.GroupBy(e => new { id = e.EmpId, name = e.Name })
                        .Select(e => new Employee
                        {
                            EmpId = e.Key.id,
                            Name = e.Key.name,
                            EmpMonthlySal = e.Select(ms => new EmpMonthSal
                            {
                                EmpId = e.Key.id,
                                Month = ms.month,
                                Sal = ms.sal
                            }).ToList()
                        });
