	foreach (WorkerViewModel member in workShiftDetailViewModel.WorkShiftEmployees)
	{
		if (member.isDeleted == false)
		{
			WorkShiftTeam emp = new WorkShiftTeam();
			emp.EmployeeId = member.EmployeeId;
			emp.RoleId = member.RoleId;
			emp.WorkShiftId = ws.WorkShiftId;
			// test = ws.WorkShiftId; test? no. defined where?
			_context.Add(emp);
			WorkShiftTask task = new WorkShiftTask();
			task.WorkShiftId = ws.WorkShiftId;  // There's the ws.WorkShiftId you were mentioning...
			// set other members of "task"
			_context.Add(task);
			await _context.SaveChangesAsync();
		}
	}
