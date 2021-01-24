    Scenario: Employee Search
    Given Application is logged
    And Search for an employee
    [When(@"Search for employee]
    public void WhenSearchEmployee ()
    {
    //would look something like this...
            EmployeeRecord.SearchEmployee(envData.empName, envData.EmployeeID, envData.Company, envData.Designation);
       
        }
