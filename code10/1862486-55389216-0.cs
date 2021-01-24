[AllowAnonymous]
    public class ReviewApplicationsModel : PageModel
    {
        readonly UserManager<ApplicationUser> userManager;
        public ReviewApplicationsModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public string ReturnUrl { get; set; }
        [BindProperty]
        public ObservableCollection<ApplicationUser> UnapprovedApplications { get; set; }
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            UnapprovedApplications = new ObservableCollection<ApplicationUser>();
            foreach (var user in userManager.Users.Where(x => !x.Approved))
                UnapprovedApplications.Add(user);
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
                return Page();
            foreach (var user in UnapprovedApplications.Where(x => x.Approved))
            {
                var tmp = await userManager.FindByIdAsync(user.Id);
                tmp.Approved = true;
                await userManager.UpdateAsync(tmp);
            }
            return RedirectToPage();
        }
    }
@page
@model ReviewApplicationsModel
@{
    ViewData["Title"] = "Review Applications";
    ViewData["ActivePage"] = ManageNavPages.ReviewApplications;
}
<h4>@ViewData["Title"]</h4>
<div class="row">
    <form method="post">
        <div class="col-md-auto">
            <button type="submit" class="btn btn-primary">Approve Selected Applications</button>
            <table class="table">
                <thead>
                    <tr>
                        <th hidden>@Html.DisplayNameFor(x => x.UnapprovedApplications.FirstOrDefault().Id)</th>
                        <th>@Html.DisplayNameFor(x => x.UnapprovedApplications.FirstOrDefault().Organization)</th>
                        <th>@Html.DisplayNameFor(x => x.UnapprovedApplications.FirstOrDefault().FEIEIN)</th>
                        <th>@Html.DisplayNameFor(x => x.UnapprovedApplications.FirstOrDefault().State)</th>
                        <th>@Html.DisplayNameFor(x => x.UnapprovedApplications.FirstOrDefault().Approved)</th>
                    </tr>
                </thead>
                <tbody>
                    @for (var i = 0; i < Model.UnapprovedApplications.Count(); i++)
                    {
                    <tr>
                        <td hidden><input asp-for="UnapprovedApplications[i].Id" class="form-control" hidden /></td>
                        <td><input asp-for="UnapprovedApplications[i].Organization" class="form-control" disabled /></td>
                        <td><input asp-for="UnapprovedApplications[i].FEIEIN" class="form-control" disabled /></td>
                        <td><input asp-for="UnapprovedApplications[i].State" class="form-control" disabled /></td>
                        <td><input asp-for="UnapprovedApplications[i].Approved" class="form-control" /></td>
                    </tr>
                    }
                </tbody>
            </table>
        </div>
    </form>
</div>
@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
there has to be a more flexible way to do this and I hope to discover it one day but this works for right now
