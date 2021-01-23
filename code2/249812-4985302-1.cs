    @model Social.ViewModels.ProductViewModelList
    <div class="info_result">
        <h2>
            @Html.ActionLink(
                Html.TruncateText(Model.Title, 25), 
                "Details", 
                new { id = Model.ProductId }
            )
        </h2>
        <p>  
            @Html.ActionLink(
                Html.TruncateText(Model.Description, 180), 
                "Details", 
                new { id = item.ProductId }
            )
        </p>
        <!-- I've modified this to use a display template instead of String.Format
        Now you only need to decorate your view model property with the DisplayFormat attribute like this:
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM d, yyyy}")]
        public DateTime? CreatedOn { get; set; }
        -->
        @Html.DisplayFor(x => x.CreatedOn)
    </div>
