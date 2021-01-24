    int callCounter = 1;
    mockContext.Setup(m => m.Employees)
        .Returns(() =>
        {
            if (callCounter == 1)
            {
                callCounter++;
                return employeeToEditMockCU;
            }
            else
            {
                return employeeMockCU;
            }
        });
