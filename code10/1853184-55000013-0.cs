    public static class EmployeeExtension
    {
	  public static int WordCount(this String str)
	  {
		var repo = new EmployeeAdvantagesRepository();
		var enumRoleAdvantages = 
			repo.GetAll().Where(ea => ea.RoleEnum == employee.RoleEnum).ToList();
		enumRoleAdvantages.AddRange(employee.VirtualListOfAdvantages);
		return enumRoleAdvantages;
	  }
    }
