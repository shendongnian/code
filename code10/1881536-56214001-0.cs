@Html.TextBoxFor(
    model => model.NewPriceList.PriceFrom , 
    "{0:yyyy-MM-dd}",
    new { 
        @type= "date",
        @value = Model.NewPriceList.PriceFrom
    }
)
Approach 2:
@Html.TextBoxFor(
    model => model.NewPriceList.PriceFrom , 
    "{0:yyyy-MM-dd}",
    new { 
        @type= "date",
    }
)
Approach 3:
<input asp-for="NewPriceList.PriceFrom" >
