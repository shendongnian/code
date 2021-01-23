    @model ParentChildViewModel
    ...
    @using(Html.BeginForm())
    {
      @Html.TextBoxFor(x => x.Master.FieldA);
    
      @{ int index = 0; }
      @foreach(var c in Model.Children)
      {
        @Html.Hidden("data.Children.Index", index);
        @Html.TextBox("data.Children[" + index + "].Name")
        @{ index++; }
      }
    }
