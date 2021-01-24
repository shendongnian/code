    //Update method in the repository base
    //Made method virtual to enable overriding
    public virtual void Update(TEntity entity)
    {
        if (entity != null)
            _dbSet.Update(entity);
    }
    //Update method from EmployeeRepository
    public override void Update(Employee employee)
    {
        var employeeFromStore = _unitOfWork.Employees.Where(p => p.Id == employee.Id)
            .Include(p => p.Beneficiaries)
            .SingleOrDefault();
        if (employeeFromStore != null)
        {
            context.Entry(employeeFromStore).CurrentValues.SetValues(employee);
            //Replacing the whole collection
            foreach (var beneficiary in employeeFromStore.Beneficiaries)
            {
                if (employee.Beneficiaries.Any())
                    context.Entry(beneficiary).State = EntityState.Deleted;
            }
            //Adding new collection
            foreach (var beneficiaryToAdd in employee.Beneficiaries)
            {
                var newBeneficiary = new Beneficiary(beneficiaryToAdd.EmployeeId, beneficiaryToAdd.Name);
                employeeFromStore.AddBeneficiary(newBeneficiary.Name);
            }
        }
    }
