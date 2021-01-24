@model MemeGenerator.Models.Memy
@{
    ViewData["Title"] = "CreateMeme";
}
<h2>CreateMeme</h2>
@using (Html.BeginForm("Create", "Memy", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    <div class="form-group">
        @Html.LabelFor(model => model.Title, "Title")
        @Html.TextBoxFor(model => model.Title, new { @class = "form-control", placeholder = "Give title" })
        @Html.ValidationMessageFor(model => model.Title, "", new { @class = "text-danger" })
    </div>
    <div class="form-group">
        @Html.LabelFor(model => model.Description, "Description")
        @Html.TextBoxFor(model => model.Description, new { @class = "form-control", placeholder = "Give description" })
        @Html.ValidationMessageFor(model => model.Description, "", new { @class = "text-danger" })
    </div>
   
    <div class="form-group">
        @Html.DropDownListFor(m => m, GetCategories(Model),
                   "Give a category of meme")
    </div>
and in MemyController
 public class MemyController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        //1 MB
        const long fileMaxSize = 1 * 1024 * 1024;
        memyContext db = new memyContext();
        public class helpers
        {
            private readonly memyContext _context;
            public helpers(memyContext context)
            {
                _context = context;
            }
           
            public  IEnumerable<SelectListItem> GetCategories()
            {
                // your context
                return new SelectList(_context.Categories.OrderBy(x => x.NameCategory), "IdCategory ", "NameCategory ");
            }
        }
and I have this error:The name "GetCategories" does not exist in the current context.Somebody have that problem?
