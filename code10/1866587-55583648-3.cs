using IdentityCore.Models;
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            /*services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();*/
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.Stores.MaxLengthForKeys = 128) // preserve string length of keys
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultUI()
               .AddDefaultTokenProviders();
**Data/ApplicationDbContext.cs**
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityCore.Models;
namespace IdentityCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyView> MyViews { get; set; }
    }
}
**Pages/Shared/_LoginPartial.cshtml**
@using Microsoft.AspNetCore.Identity;
@using IdentityCore.Models;
@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager
**Models/ApplicationUser.cs**
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace IdentityCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }
        public virtual ICollection<MyView> MyViews { get; set; }
    }
}
**Models/ApplicationRole.cs**
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace IdentityCore.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
    }
}
**Models/MyView.cs**
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace IdentityCore.Models
{
    public class MyView
    {
        [Key]
        public int MyViewId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(450)")] // match with primary key
        [ForeignKey("User")]                 // primary key AspNetUseres.Id
        public string UserId { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string Column1 { get; set; }
        [Required]
        public string Column2 { get; set; }
        [Required]
        public string Column3 { get; set; }
    }
}
**Pages/MyViews/Index.cshtml.cs**
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityCore.Data;
using IdentityCore.Models;
namespace IdentityCore.Pages.MyViews
{
    public class IndexModel : PageModel
    {
        private readonly IdentityCore.Data.ApplicationDbContext _context;
        public IndexModel(IdentityCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<MyView> MyView { get;set; }
        public async Task OnGetAsync()
        {
            MyView = await _context.MyViews
                .Include(m => m.User).ToListAsync();
        }
    }
}
**Pages/MyViews/Index.cshtml**
@page
@model IdentityCore.Pages.MyViews.IndexModel
@{
    ViewData["Title"] = "Index";
}
<h2>Index</h2>
<p>
    <a asp-page="Create">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>@Html.DisplayNameFor(model => model.MyView[0].User)</th>
            <th>@Html.DisplayNameFor(model => model.MyView[0].Column1)</th>
            <th>@Html.DisplayNameFor(model => model.MyView[0].Column2)</th>
            <th>@Html.DisplayNameFor(model => model.MyView[0].Column3)</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model.MyView) {
        <tr>
            <td>@Html.DisplayFor(modelItem => item.User.UserName)</td>
            <td>@Html.DisplayFor(modelItem => item.Column1)</td>
            <td>@Html.DisplayFor(modelItem => item.Column2)</td>
            <td>@Html.DisplayFor(modelItem => item.Column3)</td>
            <td>
                <a asp-page="./Edit" asp-route-id="@item.MyViewId">Edit</a> |
                <a asp-page="./Details" asp-route-id="@item.MyViewId">Details</a> |
                <a asp-page="./Delete" asp-route-id="@item.MyViewId">Delete</a>
            </td>
        </tr>
}
    </tbody>
</table>
