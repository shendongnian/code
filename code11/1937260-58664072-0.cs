@page
@model MyApp.Namespace.TestValidation2Model
@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>TestValidation</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</head>
<body>
    <h1>Test Validation</h1>
    <form method="post">
        @*<div asp-validation-summary="All" class="text-danger"></div>*@
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">ObjectToValidate1 - posts with empty handler, validates server side.</div>
                    <div class="card-body">
                        <div class="form-group">
                            <label class="control-label">Borrower Type</label>
                            <select asp-for="ObjectToValidate1.Item" asp-items="@Model.DDLItems" class="form-control" onchange="changeBorrowerType();"></select>
                            <span asp-validation-for="ObjectToValidate1.Item" class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <label class="control-label"></label>
                            <label asp-for="ObjectToValidate1.RequiredString" class="control-label businessName"></label>
                            <input asp-for="ObjectToValidate1.RequiredString" class="form-control autofocus" />
                            <span asp-validation-for="ObjectToValidate1.RequiredString" class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <label asp-for="ObjectToValidate1.RequiredStringIfItem1Selected" class="control-label"></label>
                            <input asp-for="ObjectToValidate1.RequiredStringIfItem1Selected" class="form-control" />
                            <span asp-validation-for="ObjectToValidate1.RequiredStringIfItem1Selected" class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <button type="submit" class="btn btn-success" asp-page-handler="">Submit</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    @*<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.17.0/jquery.validate.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>*@
</body>
</html>
The PageModel:
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MyApp.Namespace
{
    public class TestValidation2Model : PageModel
    {
        [BindProperty]
        public InputValues2 ObjectToValidate1 { get; set; }
        public List<SelectListItem> DDLItems { get; set; }
        public void OnGet()
        {
            ObjectToValidate1 = new InputValues2();
            InitializeDDLItems();
        }
        public ActionResult OnPost()
        {
            ModelState.ClearValidationState(nameof(ObjectToValidate1.RequiredString));//.Clear();
            ModelState.ClearValidationState(nameof(ObjectToValidate1.Item));//.Clear();
            ModelState.ClearValidationState(nameof(ObjectToValidate1.RequiredStringIfItem1Selected));
            //ModelState.Clear();
            TryValidateModel(ObjectToValidate1);
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ModelState);
            if (ModelState.IsValid)
            {
                // Refresh current page
                return RedirectToPage("./TestValidation2");
            }
            InitializeDDLItems();
            return Page();
        }
        private void InitializeDDLItems()
        {
            DDLItems = new List<SelectListItem>
            {
                new SelectListItem("-- Select an Item -- ", ""),
                new SelectListItem("Item 1", "1"),
                new SelectListItem("Item 2", "2"),
            };
        }
    }
    public class InputValues2
    {
        [Display(Name = "Item")]
        public int Item { get; set; }
        [Display(Name = "Required String")]
        public string RequiredString { get; set; }
        [Display(Name = "Conditional Required String")]
        public string RequiredStringIfItem1Selected { get; set; }
    }
    public class Validator2 : AbstractValidator<InputValues2>
    {
        public Validator2()
        {
            RuleFor(i => i.Item).NotEmpty().WithMessage("Item is required");
            RuleFor(i => i.RequiredString).NotEmpty().WithMessage("Required String is required");
            When(i => i.Item.Equals(1), () =>
            {
                RuleFor(e => e.RequiredStringIfItem1Selected).NotEmpty().WithMessage("Conditional Required String is required if Item 1 selected");
            });
        }
    }
}
