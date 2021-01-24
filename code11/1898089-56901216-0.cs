    var tempData = Payrolls
	.Join(Users, pyr => pyr.UsersId, usr => usr.UsersId, (pyr, usr) => new { pyr, usr })
	.Join(UserRegisters, usr => usr.usr.UsersId, urg => urg.UsersId, (usr, urg) => new { usr, urg })
	.OrderBy(p => p.usr.usr.PersonnelSurname)
	.ThenBy(p => p.usr.usr.PersonnelName)
	.OrderBy(p => p.usr.pyr.SalaryMonth)
	.ThenBy(p => p.usr.pyr.SalaryYear)
	.Select(p => new
	{
		PayrollId = p.usr.pyr.PayrollId,
		PersonelId = p.usr.pyr.UsersId,
		IdentNumber = p.usr.usr.IdentNumber.Decrypt(),
		PersonnelName = p.usr.usr.PersonnelName.Decrypt(),
		PersonnelSurname = p.usr.usr.PersonnelSurname.Decrypt(),
		SalaryMonth = p.usr.pyr.SalaryMonth,
		SalaryYear = p.usr.pyr.SalaryYear,
		WorkerRegNo = p.urg.WorkerRegNo.Decrypt(),
		NetPaid = p.usr.pyr.NetPaid2
	})
	.Take(100)
	.ToList();
