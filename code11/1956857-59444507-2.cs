    <p>@SelectedYear</p>
    
    <EditForm Model="@employees">
        <DataAnnotationsValidator />
         <div>   
            <InputSelect @bind-Value="SelectedYear" Id="SelectedYear" Class="form-control">
                @for (int i = 2015; i < DateTime.Now.Year + 1; i++)
                {
                    <option value="@i">@i</option>
                }
            </InputSelect>
           
    
        </div>
        <button type="submit">Ok</button>
    
    </EditForm>
    
    @code
     {
        private string SelectedYear { get; set; } = "2018";
    
        public List<Employee> employees = new List<Employee>();
      
    
        public class Employee
        {
            public int YearBorn { get; set; }
            public string Name { get; set; }
        }
    }
