    public class EmployeeValidator: ValidationDef<Employee>
    {
	public EmployeeValidator() {
		ValidateInstance.By((employee, context) => {
			bool isValid = true;
			if (string.IsNullOrEmpty(employee.FullName.FirstName)) {
				isValid = false;
				context.AddInvalid<Employee, string>(
					"Please enter a first name.", c => c.FullName.FirstName);
			} // Similar for last name
			return isValid;
		});
	}
    }
