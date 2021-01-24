    @model MyProject.Models.ApplicationUser
    <h3>
        @Html.DisplayFor(m => Model.FirstName)
        @Html.DisplayFor(m => Model.LastName)
    </h3>
    @if (Model.Customer != null && Model.Customer.CustomerId != null)
    {
        <div class="form-group">
            <strong>Tax ID:</strong>
            @Html.DisplayFor(m => m.Customer.TaxId)
        </div>
    } else {
    }
    @if (Model.Investor != null && Model.Investor.InvestorId != null)
    {
        <div class="form-group">
            <strong>Social Security #:</strong>
            @Html.DisplayFor(m => m.Investor.SsnNum)
        </div>
        <div class="form-group"> 
            <strong>Date of birth:</strong>
            @Html.DisplayFor(m => m.Investor.DOB)
        </div>
    } else {
    }
