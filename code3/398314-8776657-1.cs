    @model System.Generic.Collections.List<MyNameSpace.Product>
    @{
        int i = 1;
        string sortablei = "abc",
               droptrue = "abc-cls";
    }
    
    <ul id="@sortablei" class="@droptrue">
        @foreach (var item in Model)
        {
           <li>@item.Qty x @item.Name</li>
           i++;
        }
    </ul>
