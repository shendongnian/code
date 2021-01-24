    <EditForm Model="@employee" OnValidSubmit="@HandleValidSubmit">
        <DataAnnotationsValidator />
        <ValidationSummary />
    
        <InputText id="name" @bind-Value="@employee.Name" />
        <!-- <InputNumber step=".01" class="form-control form-control-xs" @bind-Value="@employee.Salary" /> -->
      
       <InputNumber step=".01" class="form-control form-control-xs" @bind-Value="@employee.Salary" @oninput="@((e) => CalculationHere(e))" />
        <button type="submit">Submit</button>
    </EditForm>
    
    <p>Salary: @employee.Salary</p>
    <p>After calculation: @calculation</p>
    @code{
     decimal calculation;
    
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
         void CalculationHere(ChangeEventArgs e)
    {
        calculation = Convert.ToDecimal(e.Value) * Convert.ToDecimal(1.2);
    }
    }
