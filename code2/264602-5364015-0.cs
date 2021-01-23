     public virtual int CreateNewEmployee(Employee newEmployee)
            {
                if (newEmployee.EntityState == EntityState.Detached)
                    _DatabaseContext.Employees.Attach(newEmployee);
                _DatabaseContext.ObjectStateManager.ChangeObjectState(newEmployee, EntityState.Added);
                int numberOfAffectedRows = _DatabaseContext.SaveChanges();
                return newEmployee.EmployeeId;
            }
