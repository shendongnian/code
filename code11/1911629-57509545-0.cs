`csharp
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
`
HomeController.cs
`csharp
    public class HomeController : Controller
    {
        public IActionResult Employees()
        {
            var list = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = "EmployeeID",
                    Address = "Address",
                    Birthday = DateTime.Now,
                    ContactNo = "ContactNo",
                    Department = "Department",
                    Email = "Email",
                    EmployeeName = "EmployeeName",
                    Gender = "Gender",
                    Position = "Position",
                    Status = "Status"
                },
                new Employee
                {
                    EmployeeID = "EmployeeID2",
                    Address = "Address",
                    Birthday = DateTime.Now,
                    ContactNo = "ContactNo",
                    Department = "Department",
                    Email = "Email",
                    EmployeeName = "EmployeeName",
                    Gender = "Gender",
                    Position = "Position",
                    Status = "Status"
                }
            };
            return View(list);
        }
    }
`
Employees.cshtml
`
@model IEnumerable<WebApplication6.Controllers.Employee>
@{
    ViewData["Title"] = "Employees";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<h1>Employees</h1>
<p>
    <a asp-action="Create">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.EmployeeID)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.EmployeeName)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Address)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Email)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.ContactNo)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Gender)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Birthday)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Status)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Position)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Department)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        @if (Model == null)
        {
            <tr>
                <td colspan="7" class="text-center">No Model Data</td>
            </tr>
        }
        else
        {
            foreach (var list in Model)
             {
                 <tr>
                     <td>@Html.DisplayFor(Model => list.EmployeeID)</td>
                     <td>@Html.DisplayFor(Model => list.EmployeeName)</td>
                     <td>@Html.DisplayFor(Model => list.Address)</td>
                     <td>@Html.DisplayFor(Model => list.Email)</td>
                     <td>@Html.DisplayFor(Model => list.ContactNo)</td>
                     <td>@Html.DisplayFor(Model => list.Gender)</td>
                     <td>@Html.DisplayFor(Model => list.Birthday)</td>
                     <td>@Html.DisplayFor(Model => list.Status)</td>
                     <td>@Html.DisplayFor(Model => list.Position)</td>
                     <td>@Html.DisplayFor(Model => list.Department)</td>
                     <td>
                         <button class="btn-default" asp-action="Update" asp-route-id="@list.EmployeeID">Edit</button>
                     </td>
                     <td>
                         <form asp-action="Delete" method="post" asp-route-id="@list.EmployeeID">
                             <button class="btn-danger">Delete</button>
                         </form>
                     </td>
                 </tr>
             }
        }
    </tbody>
</table>
`
It all works for me.
Result image:
[/home/employees][1]
  [1]: https://i.stack.imgur.com/4h4ni.png
