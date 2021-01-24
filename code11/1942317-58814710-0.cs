    @page "/Test"
    @using BlazorApp1.Data.Gage
    @using BlazorApp1.Data.ERP
    @inject GageService gageService
    @inject ErpService erpService
    <EditForm Model="@NwDset">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <table border="0" cellpadding="20">
        <thead>
            <tr>
                <th>Department</th>
                <th>ControlNo</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in NwDset)
            {
                <tr>
                    <td>
                        <p>
                            <label for="">Department:</label>
                            <InputSelect id="Department" class="form-control" placeholder="Department" @bind-Value="item.Department">
                                @foreach (var department in departments)
                                    {
                                    <option value="@department.Departmentname">
                                        @department.Departmentname
                                    </option>
                                    }
                            </InputSelect>
                            <ValidationMessage For="@(() => item.Department)" />
                        </p>
                    </td>
                    <td>
                        <p>
                            <label for="ControlNo">Control Number:</label>
                            <InputText id="ControlNo" class="form-control"
                                       placeholder="Control Number"
                                       @bind-Value="item.ControlNo" />
                            <ValidationMessage For="@(() => item.ControlNo)" />
                        </p>
                    </td>
                </tr>
            }
        </tbody>
    </table>
    
    <button type="submit">Submit</button>
    </EditForm>
    @code {
    List<GageMaster> NwDset;
    List<Department> departments;
    protected override async Task OnInitializedAsync()
    {
        NwDset = await gageService.GetGageAsync();
        departments = await erpService.GetDepartmentAsync();
    }
    }
