    <EditForm Model="@employee" OnValidSubmit="@HandleValidSubmit">
        <DataAnnotationsValidator />
        <ValidationSummary />
    
        <InputText id="name" @bind-Value="@employee.Name" />
        <InputNumber step=".01" class="form-control form-control-xs" @bind-Value="@employee.Salary" />
    
        <button type="submit">Submit</button>
    </EditForm>
    
    <p>@employee.Salary</p>
    
    @code{
    
    
            Employee employee = new Employee() { Name = "Davolio Nancy", Salary =   234 } ;
    
    
    
        public class Employee
        {
    
            public string Name { get; set; }
            private decimal salary { get; set; }
    
            public decimal Salary
            {
                get
                {
                    return salary;
                }
                set
                {
                    salary = value;
    
                    //CalculationHere();
                }
            }
        }
    
        private void HandleValidSubmit()
        {
    
        }
    }
