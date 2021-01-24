    @using Syncfusion.EJ2.Blazor
    @using Syncfusion.EJ2.Blazor.Buttons
    @using Syncfusion.EJ2.Blazor.Data
    @using Syncfusion.EJ2.Blazor.Grids
    
    
    If you want to use the same approach in 17.3.0.21-beta version, then kindly specify the query property value in form of string (like below). 
    
    <EjsGrid ModelType="Model" DataSource="@Employees" Height="315px">
        <GridTemplates>
            <DetailTemplate>
                @{
                    var employee = (context as EmployeeData);             
                    <EjsGrid DataSource="@Orders" Query="@QueryData(employee)">
    . . . . . . 
                    </EjsGrid>
                }
            </DetailTemplate>
        </GridTemplates>
    . . . . . . .. . . 
    </EjsGrid>
    
    @code{
        public int? Val { get; set; }
        public EmployeeData Model = new EmployeeData();
        public string QueryData(EmployeeData employee)
        {
            return $"new ej.data.Query().where('EmployeeID', 'equal', {employee.EmployeeID})";
        }  
    . . . . . . . .. 
    
        public class EmployeeData
        {
            public int? EmployeeID { get; set; }
            . . . . . . . . . 
        }
    }
