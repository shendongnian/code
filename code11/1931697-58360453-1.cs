        @model TechnoTent.Models.ViewModel.OrderVM
        
        @using (Html.BeginForm("EditOrder", "AdminOrder", FormMethod.Post, new { 
        @class = "product-edit", enctype = "multipart/form-data" }))
        {
            @Html.AntiForgeryToken()        
            for(int i=0; i < Model.Items.Count;i++)
            {
    @Html.TextBox("Items["+i+"].ItemCount", "2.5", new { 
                @class="input_quantity-value", value = "2.5", data_type="area", data_width="2.5"})
            }
        }
