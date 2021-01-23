    @model Tale
    <div class="item">
        @Html.ActionLink(
            Model.NameAn, 
            Model.RouteNameAn, 
            Model.AuthorTalesCategory.RouteNameAn
        )
        <span>
            @Html.Raw(Html.TimeForReadingHtmlResult((int)t.TimeForReading))
        </span>
        @Html.Raw(Html.AuthorTaleVoterHtmlResult((int)Model.Analit))
    </div>
