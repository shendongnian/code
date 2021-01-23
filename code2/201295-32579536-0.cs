                                         join x in db.EmployeeCommission on a.EmployeeDetailID equals x.EmployeeDetailID into EmployeeCommission
                                         from x in dataComm.DefaultIfEmpty()
                                         join c in db.EmployeeAdvance on a.EmployeeDetailID equals c.FKEAEmployeeID
                                         join d in db.EmployeeAllowance on a.EmployeeAllowanceID equals d.EmployeeAllowanceID
                                         join e in dataAtt on a.EmployeeDetailID equals e.EmployeeDetailID
                                         join f in dataDri on a.EmployeeDetailID equals f.EmployeeDetailID
                                         join h in db.ProjectAllocation on f.FKAllocationID equals h.PKAllocationID
                                         join i in db.ProjectDetails on h.FKProjectDetailID equals i.ProjectDetailID
                                         where a.IsActive == true && c.EAIsActive == true && d.IsActive == true && e.EAIsActive == true && h.IsActivity == true
                                         select new
                                         {
                                             c.BalanceAmount,
                                             c.BalanceDue,
                                             d.FoodAllowance,
                                             i.DriverBasicSalary,
                                             d.OtherAllowance,
                                             d.AccommodationAllowance,
                                             e.EABasicWorktime,
                                             BonusAmount = (b.BonusAmount == null ? 0 : b.BonusAmount),
                                             CommissionAmount = (x.CommissionAmount == null ? 0 : x.CommissionAmount),
                                             TotalOverTime,
                                             TotalHr
                                         }).FirstOrDefault();
