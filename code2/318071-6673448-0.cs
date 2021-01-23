    <script src="<%= Url.Content("~/Scripts/MicrosoftAjax.js") %>" type="text/javascript"></script>
     <script src="<%= Url.Content("~/Scripts/MicrosoftMvcAjax.js") %>" type="text/javascript"></script>
        <% using (Ajax.BeginForm("/GetProducts",
            new AjaxOptions()
            {
                InsertionMode = InsertionMode.Replace,
                HttpMethod = "POST",
                OnBegin = "beginSearchLoader",
                OnComplete = "completeSearchLoader",
                UpdateTargetId = "divSelectionResult"
            }
        ))
     { %>
    
                <div id="divSelectionResult">
                    <% Html.RenderPartial(Html.ProductViewPath("ProductContainer") , Model); %>
                </div>
        public ActionResult GetProducts(FormCollection form)
        {
          //search parameters used in Form 
          ProductModel modelData = Search(form); 
          ViewData.Model = modelData; 
          
          //AJAX Partial View Return
          return PartialView(Constants.VIEW_FOLDER + "ProductContainer" + Constants.PARTIALVIEW_EXTENSION);
        }
 
